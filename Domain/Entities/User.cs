using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Video> Videos { get; set; }
    }
}
