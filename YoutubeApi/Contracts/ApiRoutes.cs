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
            public const string UpdateUser = Base + "/UpdateUser/{user}/{password}/";

        
        }
        public static class video
        {
            public const string CreateVideo = Base  + "/CreateVideo/";
            public const string Get = Base + "/Get/{id}";
            public const string GetVideo = Base + "/GetVideo/";
            public const string DeleteVideo = Base + "/DeleteUser/{username}/{Password}/{videoName}/";
            public const string UpdateVideo = Base + "/UpdateVideo/{username}/{Password}/{videoName}/{newVideoName}/{url}/";
            public const string LikeVideo = Base + "/LikeVideo/{username}/{Password}/{videoName}/";


        }
        
    }
}
