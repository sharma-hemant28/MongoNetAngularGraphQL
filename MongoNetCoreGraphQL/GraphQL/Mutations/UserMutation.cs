using MongoNetCoreGraphQL.GraphQL.Inputs;
using MongoNetCoreGraphQL.Models;
using MongoNetCoreGraphQL.Services;

namespace MongoGraphQLDemo.GraphQL.Mutations
{
    public class UserMutation
    {
        public User CreateUser(AddUserInput input, [Service] UserService userService)
        {
            var user = new User
            {
                Name = input.Name,
                Email = input.Email
            };

            return userService.Create(user);
        }
    }
}
