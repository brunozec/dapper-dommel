﻿using Xunit;

namespace Brunozec.Dapper.Dommel.Tests
{
    public class CountTests
    {
        private static readonly ISqlBuilder SqlBuilder = new SqlServerSqlBuilder();

        [Fact]
        public void GeneratesCountAllSql()
        {
            var sql = DommelMapper.BuildCountAllSql(SqlBuilder, typeof(Foo));
            Assert.Equal("select count(*) from [Foos]", sql);
        }

        [Fact]
        public void GeneratesCountSql()
        {
            var sql = DommelMapper.BuildCountSql<Foo>(SqlBuilder, x => x.Bar == "Baz", out var parameters);
            Assert.Equal("select count(*) from [Foos] where ([Bar] = @p1)", sql);
            Assert.Single(parameters.ParameterNames);
        }

        private class Foo
        {
            public string? Bar { get; set; }
        }
    }
}
