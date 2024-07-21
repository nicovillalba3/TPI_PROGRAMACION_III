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

        private static List<User> _users = new List<User>();
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

        public Task<bool> UpdateUserAsync(UserForUpdateRequest user)
        {
            var existingUser = _users.SingleOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return Task.FromResult(false); // El usuario no existe
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;

            return Task.FromResult(true);
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return await Task.FromResult(false); // El usuario no existe
            }

            _users.Remove(user);
            return await Task.FromResult(true);
        }

    }
}
