using XunitTestMoqApi.Data;
using XunitTestMoqApi.Models;

namespace XunitTestMoqApi.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProductList();
        public Product GetProductById(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int Id);
    }
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Product.ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Product.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Product.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Product.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
