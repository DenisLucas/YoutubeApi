using System;
using Application.Response;
using MediatR;

namespace Application.Command
{
    public class RegistrateUserCommand : IRequest<UserRegistrationResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
