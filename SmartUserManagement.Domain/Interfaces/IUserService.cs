using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Domain.Interfaces
{
    public interface IUserService
    {
        List<User> GetActiveUsers();
        User ? GetActiveUserById(int id);
        void CreateUser(User user);
        void UpdateActiveUser(User user);
        void DeleteActiveUser(int id);
    }
}
