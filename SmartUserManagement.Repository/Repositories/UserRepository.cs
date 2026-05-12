using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartUserManagement.Domain.Interfaces;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataStore _dataStore;

        public UserRepository(IDataStore datastor)
        {
            _dataStore = datastor;
        }

        public List<User> GetAllUsers()
        {
            return _dataStore.Users;
        }

        public User? GetUserById(int id)
        {
            return _dataStore.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _dataStore.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dataStore.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                //existingUser.Email = user.Email;
                // Update other properties as needed
            }
        }

        public void DeleteUser(int id)
        {
            var user = _dataStore.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dataStore.Users.Remove(user);
            }
        }
    }
}