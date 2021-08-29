namespace RocketMan.Core.Entities.Base
{
    public class BaseEntity<TypeId> : IBaseEntity<TypeId>
    {
        public virtual TypeId Id { get; protected set; }

        private int? _requestedHashCode;

        public bool IsTransient()
        {
            return Id.Equals(default(TypeId));
        }

        public override bool Equals(object obj)
        {
            if (obj is not BaseEntity<TypeId> item)
                return false;

            if (ReferenceEquals(this, item))
                return true;

            if (GetType() != item.GetType())
                return false;

            if (item.IsTransient() || IsTransient())
                return false;
            return item == this;
        }

        public override int GetHashCode()
        {
            if (IsTransient())
                return base.GetHashCode();
            if (!_requestedHashCode.HasValue)
                _requestedHashCode =
                    Id.GetHashCode() ^
                    31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }

        public static bool operator ==(BaseEntity<TypeId> left, BaseEntity<TypeId> right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        public static bool operator !=(BaseEntity<TypeId> left, BaseEntity<TypeId> right)
        {
            return !(left == right);
        }
    }
}