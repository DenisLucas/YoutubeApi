using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class UpdateUserCommand : IRequest<UserRequest>
    {
        public string user;
        public string password;
        public int id;
        public UpdateUserCommand(string User, string Password, int Id)
        {
            user = User;
            password = Password;
            id = Id;
        }
    }
}
