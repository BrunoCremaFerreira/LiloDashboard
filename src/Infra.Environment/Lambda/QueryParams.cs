
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace LiloDash.Infra.Environment.Lambda
{
    ///<summary>
    /// Query execution response
    ///</summary>
    public class QueryParams
    {
        ///<summary>
        /// Default Page Size
        ///</summary>
        public const int DefaultTakeSize = 15;

        ///<summary>
        /// Order By string separator
        ///</summary>
        public const char OrderBySeparator = '|';

        ///<summary>
        /// Generic search text
        ///</summary>
        public string Search {get;set;} = string.Empty;

        ///<summary>
        /// Return true if Search property is defined
        ///</summary>
        public bool HasSearch
            => !string.IsNullOrWhiteSpace(Search);

        ///<summary>
        /// If true the query will be executed with pagination
        ///</summary>
        public bool IsPaginated {get;set;} = true;

        ///<summary>
        /// Start Index of pagination
        ///</summary>
        public int Skip {get;set;} =0;

        ///<summary>
        /// Size of a page
        ///</summary>
        public int Take {get;set;} = DefaultTakeSize;

        ///<summary>
        /// Current page number
        ///</summary>
        public int Page
            => Take > 0
                ? (int)Math.Ceiling((decimal)(Skip/Take)) + 1
                : 1;

        ///<summary>
        /// OrderBy delimitted string
        ///</summary>
        public string OrderBy {get;set;} = string.Empty;

        ///<summary>
        /// Order By
        ///</summary>
        public IReadOnlyDictionary<string, bool> OrderByFields
            => string.IsNullOrWhiteSpace(OrderBy)
                ? new Dictionary<string, bool>()
                : OrderBy.Split(OrderBySeparator)
                    .ToDictionary(
                        k=> k.Trim().Split(' ').FirstOrDefault()?.Trim(),
                        v=> v.EndsWith("DESC", StringComparison.InvariantCultureIgnoreCase));
        

    }
}
