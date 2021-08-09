using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Query;
using Application.Request;
using MediatR;

namespace Application.Handlers
{
    public class UserPasswordRequestHandler : IRequestHandler<GetUserQuery, UserRequest>
    {
        public AppDBContext _context;
        public UserPasswordRequestHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<UserRequest> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.Where(x=> x.Username == request.username).FirstOrDefaultAsync();

            return new UserRequest
                {
                    Username = request.username,
                    Password = user.Password
                };    
        }
   }
}
