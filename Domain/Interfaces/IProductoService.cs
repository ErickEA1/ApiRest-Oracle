using OracleDDD.Domain.Entities;

namespace OracleDDD.Domain.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAllProducts();
        Producto GetProductById(int id);
        void CreateProduct(Producto product);
        void UpdateProduct(int id, Producto product);
        void DeleteProduct(int id);
    }
}
