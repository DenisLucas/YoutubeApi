using System;

namespace Application.Response
{
    public class UserRegistrationResponse
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserReturnResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
