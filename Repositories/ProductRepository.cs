using ProductCatalogAPI.Data;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddProduct(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var delproduct = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            if (delproduct == null)
            {
                throw new Exception("Wrong");
            }

            _dataContext.Products.Remove(delproduct);
            _dataContext.SaveChanges();
            

        }

        public IEnumerable<Product> GetAll()
        {
            return _dataContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dataContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            var updproduct = _dataContext.Products.FirstOrDefault(y => y.Id == product.Id);
            if (updproduct != null)
            {
                updproduct.Price = product.Price;
                updproduct.Description = product.Description;
                updproduct.Name = product.Name;
                updproduct.Quantity = product.Quantity;
                _dataContext.Update(updproduct);
                _dataContext.SaveChanges();
            }
        }
    }
}
