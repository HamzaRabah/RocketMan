using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RocketMan.Core.Entities;
using RocketMan.Core.Exceptions;
using RocketMan.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RocketMan.Infrastructure.Dto.SpaceX;

namespace RocketMan.Infrastructure.Services
{
    public class SpaceApiService : ISpaceApiService
    {
        public async Task<IEnumerable<Launch>> GetUpcomingLaunches()
        {
            var result = await SendGetRequest<List<LaunchDto>>("launches/upcoming?id=true");
            return result.Select(_createLaunchFromDto);
        }


        public async Task<Launch> GetNextLaunch()
        {
            var result = await SendGetRequest<LaunchDto>("launches/next?id=true");
            //Workaround the date of launch is already in the past
            result.LaunchDateUnix += 30072000;
            return _createLaunchFromDto(result);
        }


        private Launch _createLaunchFromDto(LaunchDto dto)
        {
            return Launch.Create(dto.Id,
                dto.MissionName,
                DateTimeOffset.FromUnixTimeSeconds(dto.LaunchDateUnix),
                dto.LaunchSite?.SiteName);
        }

        private static async Task<TResult> SendGetRequest<TResult>(string url)
        {
            using (var httpClient = _createHttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    var errorStream = await response.Content.ReadAsStreamAsync();
                    var content = await StreamToStringAsync(errorStream);
                    throw new ExtendedHttpRequestException(response.StatusCode, content);
                }

                var stream = await response.Content.ReadAsStreamAsync();
                var result = DeserializeJsonFromStream<TResult>(stream);
                return result;
            }
        }


        private static HttpClient _createHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.spacexdata.com/v3/")
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                try
                {
                    var js = new JsonSerializer
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                        NullValueHandling = NullValueHandling.Ignore
                    };
                    js.Converters.Add(new StringEnumConverter());
                    var searchResult = js.Deserialize<T>(jtr);
                    return searchResult;
                }
                catch (JsonReaderException)
                {
                    return default(T);
                }
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            if (stream == null)
                return null;
            using var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();

            return content;
        }
    }
}