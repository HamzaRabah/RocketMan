namespace RocketMan.Core.Entities.Base
{
    public interface IBaseEntity<TypeId>
    {
        TypeId Id { get; }
    }
}
