using System;

namespace Presentation.Contracts
{
    public class ApiRoutes
    {
        public const string version = "v1";
        public const string root = "api";
        public const string Base = root + "/" + version;
        public static class user
        {
            public const string CreateUser = Base  + "/CreateUser/";
            public const string Get = Base + "/Get/{id}";
            public const string GetPassword = Base + "/GetUserPassword/{user}";

            public const string DeleteUser = Base + "/DeleteUser/{user}/{password}/";
        
        }
        
    }
}
