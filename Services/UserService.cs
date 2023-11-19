using HealthManagementBackend.Models;
using MongoDB.Driver;


namespace HealthManagementBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IHealthStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User Create(User users)
        {
            _users.InsertOne(users);
            return users;
        }

        public void Delete(string id)
        {
            _users.DeleteOne(users => users.Id == id);
        }

        public List<User> Get()
        {
            return _users.Find(users => true).ToList();
        }

        public User GetById(string id)
        {
            return _users.Find(users => users.Id == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public async Task<User> Login(string email, string password)
        {
            var users = await _users.Find(users => users.Email == email).FirstOrDefaultAsync();
            if (users != null && BCrypt.Net.BCrypt.Verify(password, users.Password))
            {
                return users;
            }
            return null;
        }

        public async Task<User> Register(User users)
        {
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
            await _users.InsertOneAsync(users);
            return users;
        }

        public void Update(string id, User users)
        {
            _users.ReplaceOne(users => users.Id == id, users);
            throw new NotImplementedException();
        }
    }
}

