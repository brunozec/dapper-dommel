﻿using System;
using System.Reflection;

namespace Brunozec.Dapper.Dommel
{
    internal enum QueryCacheType
    {
        Get,
        GetByMultipleIds,
        GetAll,
        Project,
        ProjectAll,
        Count,
        Insert,
        Update,
        Delete,
        DeleteAll,
        Any,
    }

    internal struct QueryCacheKey : IEquatable<QueryCacheKey>
    {
        public QueryCacheKey(QueryCacheType cacheType, ISqlBuilder sqlBuilder, MemberInfo memberInfo, string tableName)
        {
            SqlBuilderType = sqlBuilder.GetType();
            CacheType = cacheType;
            MemberInfo = memberInfo;
            TableName = tableName;
        }

        public QueryCacheType CacheType { get; }

        public Type SqlBuilderType { get; }

        public MemberInfo MemberInfo { get; }

        /// <summary>
        /// Table name with schema
        /// </summary>
        public string TableName { get; }

        public bool Equals(QueryCacheKey other) => 
            CacheType == other.CacheType && 
            SqlBuilderType == other.SqlBuilderType && 
            MemberInfo == other.MemberInfo &&
            TableName == other.TableName;
    }
}
