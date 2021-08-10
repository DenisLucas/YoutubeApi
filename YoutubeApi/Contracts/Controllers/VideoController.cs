using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Application.Query;
using Application.Command;
using Application.Response;
using Application.Request;

namespace Presentation.Contracts.Controllers
{
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost(ApiRoutes.video.CreateVideo)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateVideoCommand request)
        {
            var Video = await _mediator.Send(request); 
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";    
            var locationuri = BaseUrl + "/" + ApiRoutes.video.Get.Replace("{id}",Video.id.ToString());
            return Created(locationuri,
                 new VideoResponseView {
                    videoName = Video.videoName,
                    username = Video.username,
                    url = Video.url});
        }

        
        // [HttpGet(ApiRoutes.video.GetVideo)]
        
        // [HttpPut(ApiRoutes.video.UpdateVideo)]
  
        // [HttpDelete(ApiRoutes.video.DeleteVideo)]
        
    }
}
