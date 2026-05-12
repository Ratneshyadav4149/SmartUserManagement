using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartUserManagement.Domain.Interfaces;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Business.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public List<User> GetActiveUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User? GetActiveUserById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid user id");
            }
            return _userRepository.GetUserById(id);
        }

        public void CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("User name required");
            }
            var users = _userRepository.GetAllUsers();
            bool userExists = users.Any(x => x.Name.ToLower() == user.Name.ToLower());
            if (userExists)
            {
                throw new Exception("User with the same name already exists");
            }
            user.Id = users.Count + 1;
            _userRepository.AddUser(user);

        }

        public void UpdateActiveUser(User user)
        {
            if (user.Id <= 0)
            {
                throw new Exception("Invalid user id");
            }
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("User name required");
            }
            var existingUser = _userRepository.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            _userRepository.UpdateUser(user);
        }

        public void DeleteActiveUser(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid user id");
            }

            var existingUser = _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            _userRepository.DeleteUser(id);
        }
    }
}
