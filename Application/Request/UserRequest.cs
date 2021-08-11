using System.Collections.Generic;
using Application.Response;

namespace Application.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<VideoLikeResponse> Videos { get; set; }
    }
}