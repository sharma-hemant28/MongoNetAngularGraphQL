using HotChocolate;
using HotChocolate.Data;
using MongoNetCoreGraphQL.Models;
using MongoNetCoreGraphQL.Services;

namespace MongoNetCoreGraphQL.GraphQL.Queries
{
    public class UserQuery
    {
        [UseFiltering]
        [UseSorting]
        public List<User> GetUsers([Service] UserService userService) =>
            userService.Get();
    }
}
