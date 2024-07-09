using Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia
{
    public class InMemoryUser
    // ESTA CLASE SIMULA UNA BASE DE DATOS EN MEMORIA PARA GESTIONAR USUARIOS.
    // ConcurrentDictionary es una clase propia de c#.
    // _users es un diccionario que almacena objetos User.
    {
        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>(); //Se utiliza para almacenar usuarios.

        public Task<bool> AddUserAsync(User user) // Añade un nuevo usuario a la colección
        {
            if (_users.Values.Any(u => u.Email == user.Email)) // Se pregunta si hay un mismo usuario con ese correo electrónico.
            {
                return Task.FromResult(false); // El usuario ya existe
            }

            user.Id = Guid.NewGuid().ToString(); // Se genera un nuevo id.
            _users[user.Id] = user;
            return Task.FromResult(true);
        }

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password) // Obtiene un usuario de la colección que coincida con el correo electrónico y la contraseña proporcionada
        {
            var user = _users.Values.SingleOrDefault(u => u.Email == email && u.Password == password); // Busca en los valores del diccionario usuarios en los que coincidan la password y el user.
            return Task.FromResult(user);
        }
    }
}
