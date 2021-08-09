using System;
using Domain.Entities;
using MediatR;

namespace Application.Command
{
    public class RegistrateVideoCommand : IRequest
    {
        public string VideoName { get; set; }
        public string url { get; set; }
        public User User { get; set; }
    }
}
