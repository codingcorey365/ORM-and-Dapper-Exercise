namespace ORM_Dapper;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    public void UpdateProduct(int id, string newName, double newPrice); // Can update individual items in a product
    public Product GetProduct(int id); // would need to specify a product
    public void UpdateProduct(Product product); // Can update an entire product by passing one in.  
    public void CreateProduct(string name, double price, int categoryID);

    public void DeleteProduct(int id);

}