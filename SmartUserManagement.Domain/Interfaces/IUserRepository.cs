using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User ? GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
