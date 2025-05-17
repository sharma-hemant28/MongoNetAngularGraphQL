using MongoDB.Driver;
using MongoNetCoreGraphQL.Models;
using Microsoft.Extensions.Options;

namespace MongoNetCoreGraphQL.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("TestDb");
            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get() => _users.Find(user => true).ToList();

        public User Get(string id) => _users.Find(user => user.Id == id).FirstOrDefault();

        public List<User> GetByName(string name) => _users.Find(user => user.Name == name).ToList();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
