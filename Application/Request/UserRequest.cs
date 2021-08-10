using System.Collections.Generic;
using Domain.Entities;

namespace Application.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> VideosName { get; set; }
    }
}