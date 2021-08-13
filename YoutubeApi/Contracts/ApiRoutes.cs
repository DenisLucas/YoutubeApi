using System;

namespace Presentation.Contracts
{
    public class ApiRoutes
    {

        public const string root = "api";
        public const string Base = root;
        public static class user
        {
            public const string Create = Base  + "/user/";
            public const string Read = Base  + "/user/{user}";
            public const string Update = Base  + "/user/{id}/";
            public const string Delete = Base  + "/user/{user}/";            
            public const string Get = Base + "/Get/{id}";


        
        }
        public static class video
        {
            public const string create = Base  + "/video/";

            public const string read = Base  + "/video/{videoName}";

            public const string update = Base  + "/video/{username}/";

            public const string delete = Base  + "/video/{username}/{videoName}";

            public const string like = Base  + "/video/like/{username}/";
            public const string Get = Base + "/Get/{id}";


        }
        
    }
}
