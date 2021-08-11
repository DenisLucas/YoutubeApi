using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class RegistrateUserCommand : IRequest<UserRegistrationRequest>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
