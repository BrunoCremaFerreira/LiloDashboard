using System;

namespace LiloDash.Domain.Core.Models
{
    ///<summary>
    /// Base System Entity Generic Id
    ///</summary>
    public abstract class Entity<TIdType>: IEntity
    {

        #region :: Properties

        ///<summary>
        /// Unique Identifyer
        ///</summary>
        public TIdType Id { get; set; }

        ///<summary>
        /// When Created Timestamp
        ///</summary>
        public DateTime WhenCreated {get;set;} = DateTime.UtcNow;

        ///<summary>
        /// Last persistence updated
        ///</summary>
        public DateTime? WhenUpdated {get;set;}

        ///<summary>
        /// Virtual deleted timestamp
        ///</summary>
        public DateTime? WhenDeleted {get;set;}

        #endregion

        #region :: Operator

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TIdType>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<TIdType> a, Entity<TIdType> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TIdType> a, Entity<TIdType> b)
            => !(a == b);

        #endregion

        #region :: Override
        
        public override int GetHashCode()
            =>(GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString()
            => GetType().Name + " [Id=" + Id + "]";

        #endregion
        
        public object GetId()
            => Id;
    }

    ///<summary>
    /// Base System Entity
    ///</summary>
    public abstract class Entity: Entity<Guid>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}