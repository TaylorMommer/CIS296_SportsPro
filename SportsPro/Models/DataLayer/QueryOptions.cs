using System.Linq.Expressions;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace SportsPro.Models.DataLayer
{
    public class WhereClauses<T> : List<Expression<Func<T, bool>>> { };

    public class QueryOptions<T>
    {
        // public properties for sorting and filtering
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public Expression<Func<T, Object>> ThenOrderBy { get; set; }

        // private string array for include statements
        private string[] includes;

        // public write-only property for include statements - converts string to array
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        // public get method for include statements - returns private string array or empty string array
        public string[] GetIncludes() => includes ?? new string[0];

        public WhereClauses<T> WhereClauses { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }
                WhereClauses.Add(value);
            }
        }

        // read-only properties 
        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasThenOrderBy => ThenOrderBy != null;
    }
}
