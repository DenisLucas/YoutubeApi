using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using MediatR;

namespace Application.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        public AppDBContext _context;
        public DeleteUserHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var todelete =  _context.User.Where(x=> x.Username == request.user && x.Password == request.password).FirstOrDefault();
            if (todelete != null){
                _context.User.Remove(todelete);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }
    }
}
