using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Response;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<RegistrateUserCommand, UserRegistrationResponse>
    {
        public AppDBContext _context;
        public CreateUserHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<UserRegistrationResponse> Handle(RegistrateUserCommand request, CancellationToken cancellationToken)
        {
            
            var user = new User
            {
                Username = request.UserName,
                Password = request.Password   
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserRegistrationResponse 
            {
                id = user.id,
                Username = user.Username,
                Password = user.Password,
            };
            
        }
    }
}
