using BusinessObject;
using DataAccess;
using Repositories.Contracts;

namespace Repositories;

public class ProductCategory : IProductRepository
{
    public void SaveProduct(Product p) => ProductDAO.SaveProduct(p);

    public Product GetProductById(int id) => ProductDAO.FindProductById(id);

    public void DeleteProduct(Product p) => ProductDAO.DeleteProduct(p);

    public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);

    public List<Category> GetCategories() => CategoryDAO.GetCategories();

    public List<Product> GetProducts() => ProductDAO.GetProducts();
}