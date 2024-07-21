using Domain.Entities;
using Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using Infrastructure.Data;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User? Get(string name)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == name);
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                _context.SaveChanges();
            }
        }
    }
}
