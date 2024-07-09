using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    // Se define una interfaz.
    {
        Task<bool> RegisterAsync(User user); // Registrar usuario. Si ya existe el usuario retorna false
        Task<User> LoginAsync(string email, string password); // Loguear usuario.
        Task LogoutAsync(); // Desloguear usuario.
    }
}
