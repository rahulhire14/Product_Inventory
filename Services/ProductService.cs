using Product_Inventory.DAL;
using Product_Inventory.Models;


namespace Product_Inventory.Services
{
    public class ProductService
    {
        ProductDAL productDAL = new ProductDAL();
        public ProductService() { }
        public string CreateProduct(Product product)
        {
            return productDAL.CreateProduct(product);
        }

        public List<Product> GetProductByList( )
        {
            return productDAL.GetProductByList();
        }
        public List<Product> GetProductById(string id) 
        {
            return  productDAL.GetProductById(id);
        }
    } 
}
