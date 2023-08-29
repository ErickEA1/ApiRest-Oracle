using OracleDDD.Domain.Entities;

namespace OracleDDD.Domain.Interfaces
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        void Add(Producto product);
        void Update(Producto product);
        void Delete(Producto product);
        void SaveChanges();
}
}
