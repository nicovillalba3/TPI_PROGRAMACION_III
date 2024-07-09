using Domain.Entities;
using Domain.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
        //IMPLEMENTACION real de IUserService.
    {
        private static List<User> _users = new List<User>(); //LISTA ESTÁTICA DE USUARIOS.

        public Task<bool> RegisterAsync(User user)
        {
            if (_users.Any(u => u.Email == user.Email))
            {
                return Task.FromResult(false); // El usuario ya existe
            }
            user.Role = UserRole.CommonUser;
            _users.Add(user);
            return Task.FromResult(true);
        }

        public Task<User> LoginAsync(string email, string password)
        {
            var user = _users.SingleOrDefault(u => u.Email == email && u.Password == password);
            return Task.FromResult(user); // Devuelve null si el usuario no existe o la contraseña es incorrecta
        }

        public Task LogoutAsync()
        {
            // Lógica de cierre de sesión si es necesario (por ejemplo, eliminar cookies, etc.)
            return Task.CompletedTask;
        }

        public bool IsAdmin(User user)
        {
            return user.Role == UserRole.Admin; //RETORNA True si admin o false si no lo es.
        }
    }
}
