using Application.Dtos;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUserRepository _userRepository;

        public ProductService(IProductRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Product> GetAll()
        {
            return _repository.Get();
        }

        public void AddProduct(ProductForAddRequest request)
        {
            var user = _userRepository.Get(request.UserId);
            if (user == null || user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede agregar nuevos productos.");
            }

            var product = new Product()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                Image = request.Image
            };
            _repository.AddProduct(product);
        }

        public void UpdateProduct(ProductForUpdateRequest request)
        {
            var user = _userRepository.Get(request.UserId);
            if (user == null || user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede actualizar productos.");
            }

            var product = new Product()
            {
                
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                Image = request.Image
            };
            _repository.UpdateProduct(product);
        }

        public bool DeleteProduct(int id, int userId)
        {
            var user = _userRepository.Get(userId);
            if (user == null || user.Role != UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Sólo el administrador puede borrar productos.");
            }

            return _repository.DeleteProduct(id);
        }
    }
}
