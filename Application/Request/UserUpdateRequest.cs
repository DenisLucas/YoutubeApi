using System;

namespace Application.Request
{
    public class UserUpdateRequest
    {
        public string newUsername { get; set; }
        public string newPassword { get; set; }
    }
}
