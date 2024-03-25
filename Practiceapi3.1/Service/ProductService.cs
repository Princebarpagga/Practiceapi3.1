using Dapper;
using Practiceapi3._1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practiceapi3._1.Service
{
    public class ProductService : IProductService
    {
        private readonly WrapperContext _wrapperContext;
        public ProductService(WrapperContext wrapperContext)
        {

            _wrapperContext = wrapperContext;
        }
        public async Task AddProduct(Product product)
        {
            using (_wrapperContext)
            {
                _wrapperContext.Open();

                var sql = "INSERT INTO tblProducts (Name, Price) VALUES (@Name, @Price)";

                await _wrapperContext.Connection.ExecuteAsync(sql, product);
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (_wrapperContext)
            {
                _wrapperContext.Open();

                var sql = "DELETE FROM tblProducts WHERE Id = @Id";

                await _wrapperContext.Connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            using (_wrapperContext)
            {
                _wrapperContext.Open();
                var sql = "SELECT * FROM tblProducts";
                return await _wrapperContext.Connection.QueryAsync<Product>(sql);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using (_wrapperContext)
            {
                _wrapperContext.Open();

                var sql = "UPDATE tblProducts SET Name = @Name, Price = @Price WHERE Id = @Id";

                await _wrapperContext.Connection.ExecuteAsync(sql, product);
            }
        }
    }
}
