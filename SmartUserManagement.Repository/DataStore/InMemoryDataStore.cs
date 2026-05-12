using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartUserManagement.Domain.Interfaces;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Repository.DataStore
{
    public class InMemoryDataStore : IDataStore
    {
        public List<User> Users { get; } = new();
        List<User> IDataStore.Users { get => Users; set => throw new NotImplementedException(); }
    }
}
