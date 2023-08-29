using Microsoft.EntityFrameworkCore;
using OracleDDD.Domain.Entities;
using OracleDDD.Domain.Interfaces;
using OracleDDD.Infraestructure.Context;

namespace OracleDDD.Infraestructure.Repository
{
    public class ProductRepository:IProductoRepository
    {
        private readonly ContextoDatos _dbContext;

        public ProductRepository(ContextoDatos dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _dbContext.PRODUCTOS.ToList();
        }

        public Producto GetById(int id)
        {
            return _dbContext.PRODUCTOS.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Producto product)
        {
            _dbContext.PRODUCTOS.Add(product);
        }

        public void Update(Producto product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Producto product)
        {
            _dbContext.PRODUCTOS.Remove(product);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
