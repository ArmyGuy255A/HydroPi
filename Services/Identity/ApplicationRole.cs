using AspNetCore.Identity.Mongo.Model;

namespace HydroPi.Services.Identity
{
    public class ApplicationRole : MongoRole
    {
        public ApplicationRole(string roleName): base(roleName)
        {

        }
    }
}
