using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Request;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserRequest>
    {
        public AppDBContext _context;
        public UpdateUserHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<UserRequest> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.Where(x=> x.id == request.id).FirstOrDefaultAsync();

            user.id = user.id;
            user.Username = request.user.newUsername;
            user.Password = request.user.newPassword;
            await _context.SaveChangesAsync();
            return new UserRequest
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
