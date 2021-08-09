using System;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Application.Query;
using Application.Command;
using Application.Response;

namespace Presentation.Contracts.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost(ApiRoutes.user.CreateUser)]
        public async Task<ActionResult> CreateUserAsync([FromBody] RegistrateUserCommand request)
        {
            var User = await _mediator.Send(request); 
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";    
            var locationuri = BaseUrl + "/" + ApiRoutes.user.Get.Replace("{id}",User.id.ToString());
            return Created(locationuri,
                 new UserReturnResponse {
                    Username = User.Username,
                    Password = User.Password});
        }

        [HttpGet(ApiRoutes.user.GetPassword)]
        public async Task<ActionResult> GetPassword(string user)
        {
            var User = await _mediator.Send(Query); 
            
        }


    }
}
