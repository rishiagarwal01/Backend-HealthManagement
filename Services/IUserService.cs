
using HealthManagementBackend.Models;
namespace HealthManagementBackend.Services
   
{
    public interface IUserService
    {
        List<User> Get();

        User GetById(string id);

        User Create(User users);
        void Update(string id, User users);
        void Delete(string id);

        Task<User> Register(User users);
        Task<User> Login(string email, string password);
    }
}
