using System;
using System.Collections.Generic;

namespace LiloDash.Infra.Environment.Lambda
{
    ///<summary>
    /// Query execution response
    ///</summary>
    public class QueryResult<TEntity>
    {

        #region Constructors

        ///<summary>
        /// Default Constructor
        ///</summary>
        public QueryResult(){ }

        public QueryResult(QueryParams queryParams)
            :this()
            => QueryParams = queryParams;

        public QueryResult(QueryParams queryParams, IEnumerable<TEntity> result, int maxCount)
            : this(queryParams)
        {
            Result = result;
            MaxCount = maxCount;
        }

        #endregion

        ///<summary>
        /// Original Query Execution Params
        ///</summary>
        public QueryParams QueryParams {get;}

        ///<summary>
        /// Query result Data
        ///</summary>
        public IEnumerable<TEntity> Result {get;set;}

        ///<summary>
        /// Max result of execution query
        ///</summary>
        public int MaxCount {get;set;}

        ///<summary>
        /// Total pages
        ///</summary>
        public int TotalPages
            => QueryParams.Take > 0 
                ? (int)Math.Ceiling(MaxCount/(decimal)QueryParams.Take)
                : 0;
    }
}
