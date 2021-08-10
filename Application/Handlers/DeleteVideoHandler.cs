using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using MediatR;

namespace Application.Handlers
{
    public class DeleteVideoHandler : IRequestHandler<DeleteVideoCommand,bool>
    {
        public AppDBContext _context;
        public DeleteVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var video =_context.Video.Where(x=> x.VideoName == request.videoName).FirstOrDefault();
            _context.Remove(video);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
