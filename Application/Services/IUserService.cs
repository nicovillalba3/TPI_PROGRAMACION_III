using Application.Dtos;
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
        Task<User> GetCurrentUserAsync(); // Obtener el usuario actual.

        Task<bool> UpdateUserAsync(UserForUpdateRequest user);
        Task<bool> DeleteUserAsync(string id);

        bool IsAdmin(User user);
    }
}
