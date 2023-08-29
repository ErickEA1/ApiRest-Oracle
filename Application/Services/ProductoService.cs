using OracleDDD.Domain.Entities;
using OracleDDD.Domain.Interfaces;
using OracleDDD.Infraestructure.Repository;

namespace OracleDDD.Application.Services
{
    public class ProductoService:IProductoService 
    {
        private readonly IProductoRepository _productRepository;

        public ProductoService(IProductoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Producto> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Producto GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void CreateProduct(Producto product)
        {
            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        public void UpdateProduct(int id, Producto product)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                // Lanzar una excepción o manejar el error
            }

            existingProduct.Nombreproducto = product.Nombreproducto;
            existingProduct.Codigobarras = product.Codigobarras;
            existingProduct.Precio = product.Precio;
            existingProduct.Categoria = product.Categoria;
            existingProduct.Stock = product.Stock;
            existingProduct.UrlImagen = product.UrlImagen;
            existingProduct.Descripcion = product.Descripcion;


            _productRepository.Update(existingProduct);
            _productRepository.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                // Lanzar una excepción o manejar el error
            }

            _productRepository.Delete(existingProduct);
            _productRepository.SaveChanges();
        }
    }
}
