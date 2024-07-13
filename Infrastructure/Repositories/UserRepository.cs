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
            return _context.SaveChanges();
        }
    }
}
