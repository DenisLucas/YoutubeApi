using System;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string user;
        public DeleteUserCommand(string User)
        {
            user = User;
        }
    }
}
