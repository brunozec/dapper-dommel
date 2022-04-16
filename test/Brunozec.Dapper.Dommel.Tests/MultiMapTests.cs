using Xunit;

namespace Brunozec.Dapper.Dommel.Tests
{
    public class MultiMapTests
    {
        private readonly MySqlSqlBuilder _sqlBuilder = new MySqlSqlBuilder();

        [Fact]
        public void BuildMultiMapQuery_OneToOne()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(Category) }, null, out var parameters);
            var expectedQuery = "select * from `Products` left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id`";
            Assert.Equal(expectedQuery, query);
            Assert.Null(parameters);
        }

        [Fact]
        public void BuildMultiMapQuery_OneToOneSingle()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(Category) }, 1, out var parameters);
            var expectedQuery = "select * from `Products` left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id` where `Products`.`Id` = @Id";
            Assert.Equal(expectedQuery, query);
            Assert.Equal("Id", Assert.Single(parameters?.ParameterNames));
        }

        [Fact]
        public void BuildMultiMapQuery_OneToMany()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(ProductOption) }, null, out var parameters);
            var expectedQuery = "select * from `Products` left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId`";
            Assert.Equal(expectedQuery, query);
            Assert.Null(parameters);
        }

        [Fact]
        public void BuildMultiMapQuery_OneToManySingle()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(ProductOption) }, 1, out var parameters);
            var expectedQuery = "select * from `Products` left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId` where `Products`.`Id` = @Id";
            Assert.Equal(expectedQuery, query);
            Assert.Equal("Id", Assert.Single(parameters?.ParameterNames));
        }

        [Fact]
        public void BuildMultiMapQuery_OneToOneOneToMany()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(Category), typeof(ProductOption) }, null, out var parameters);
            var expectedQuery = "select * from `Products` " +
                "left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id` " +
                "left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId`";
            Assert.Equal(expectedQuery, query);
            Assert.Null(parameters);
        }

        [Fact]
        public void BuildMultiMapQuery_BuildMultiMapQuery_OneToOneOneToManySingle()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(Category), typeof(ProductOption) }, 1, out var parameters);
            var expectedQuery = "select * from `Products` " +
                "left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id` " +
                "left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId` " +
                "where `Products`.`Id` = @Id";
            Assert.Equal(expectedQuery, query);
            Assert.Equal("Id", Assert.Single(parameters?.ParameterNames));
        }

        [Fact]
        public void BuildMultiMapQuery_OneToManyOneToOne()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(ProductOption), typeof(Category) }, null, out var parameters);
            var expectedQuery = "select * from `Products` " +
                "left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId` " +
                "left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id`";
            Assert.Equal(expectedQuery, query);
            Assert.Null(parameters);
        }

        [Fact]
        public void BuildMultiMapQuery_BuildMultiMapQuery_OneToManyOneToOneSingle()
        {
            var query = DommelMapper.BuildMultiMapQuery(_sqlBuilder, typeof(Product), new[] { typeof(Product), typeof(ProductOption), typeof(Category) }, 1, out var parameters);
            var expectedQuery = "select * from `Products` " +
                "left join `ProductOptions` on `Products`.`Id` = `ProductOptions`.`ProductId` " +
                "left join `Categories` on `Products`.`CategoryId` = `Categories`.`Id` " +
                "where `Products`.`Id` = @Id";
            Assert.Equal(expectedQuery, query);
            Assert.Equal("Id", Assert.Single(parameters?.ParameterNames));
        }
    }
}
