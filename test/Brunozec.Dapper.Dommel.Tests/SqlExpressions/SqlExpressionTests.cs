using Xunit;

namespace Brunozec.Dapper.Dommel.Tests.SqlExpressions
{
    public class SqlExpressionTests
    {
        [Fact]
        public void ToString_ReturnsSql()
        {
            var _sqlExpression = new SqlExpression<Product>(new SqlServerSqlBuilder());
            var sql = _sqlExpression.Where(p => p.Name == "Chai").ToSql();
            Assert.Equal(" where ([Name] = @p1)", sql);
            Assert.Equal(sql, _sqlExpression.ToString());
        }
    }
}
