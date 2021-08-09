using System;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string user;
        public string password;
        public DeleteUserCommand(string User, string Password)
        {
            user = User;
            password = Password;
        }
    }
}
