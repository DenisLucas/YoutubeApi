using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class UpdateUserCommand : IRequest<UserRequest>
    {
        public UserUpdateRequest user;
        public int id;
        public UpdateUserCommand(UserUpdateRequest User, int Id)
        {
            user = User;
            id = Id;
        }
    }
}
