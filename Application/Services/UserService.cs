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

        public User Get(int id)
        {
            return _repository.Get(id);
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
                Password = request.Password,
                Role = request.Role
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
                Password = request.Password,
                Role = request.Role
            };
            _repository.UpdateUser(user);
        }


    }
}
