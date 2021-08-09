using System;
using MediatR;

namespace Application.Query
{
    public class GetUserQuery : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
