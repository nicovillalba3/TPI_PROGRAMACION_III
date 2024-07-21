using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Enum;

using Microsoft.AspNetCore.Http;
using Application.Dtos;

namespace Application.Services
{
    public class UserService 
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Get(string name)
        {
            return _repository.Get(name);
        }

        public List<User> GetAll()
        {
            return _repository.Get();
        }

        public int AddUser(UserForAddRequest request)
        {
            var user = new User()
            {
                UserName = request.Name,
                Email = request.Email,
                Password = request.Password
            };
            return _repository.AddUser(user);
        }
        public bool DeleteUser(int id)
        {
           return _repository.DeleteUser(id);
        }

        public void UpdateUser(UserForUpdateRequest request)
        {
            var user = new User()
            {
                Id = request.Id,
                UserName = request.Name,
                Email = request.Email,
                Password = request.Password
            };
            _repository.UpdateUser(user);
        }

    }
}
