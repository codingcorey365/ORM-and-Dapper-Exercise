namespace ORM_Dapper;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();

    public void CreateProduct(string name, double price, int categoryID);

}