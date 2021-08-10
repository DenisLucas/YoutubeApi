using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using MediatR;

namespace Application.Handlers
{
    public class LikeVideoHandler : IRequestHandler<LikeVideoCommand, bool>
    {
        public AppDBContext _context;
        public LikeVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(LikeVideoCommand request, CancellationToken cancellationToken)
        {
            var video =  _context.Video.Where(x=>x.VideoName == request.video).FirstOrDefault();
            video.favs += 1;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
