using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
         User? Get(int id);
        List<User> Get();
        int AddUser(User user);

        bool DeleteUser(int id);
        void UpdateUser(User user);

    }
}
