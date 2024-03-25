using Practiceapi3._1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practiceapi3._1.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();        
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
