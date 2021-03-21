using System;

namespace LiloDash.Domain.Core.Models
{
    public interface IEntity
    {
        ///<summary>
        /// When Created Timestamp
        ///</summary>
        DateTime WhenCreated {get;set;}

        ///<summary>
        /// Last persistence updated
        ///</summary>
        DateTime? WhenUpdated {get;set;}

        ///<summary>
        /// Virtual deleted timestamp
        ///</summary>
        DateTime? WhenDeleted {get;set;}

        ///<summary>
        /// Return raw Id instance
        ///</summary>
        object GetId();
    }
}
