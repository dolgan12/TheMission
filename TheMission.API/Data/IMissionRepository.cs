using System.Collections.Generic;
using System.Threading.Tasks;
using TheMission.API.Models;

namespace TheMission.API.Data
{
    public interface IMissionRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int userId);
    }
}