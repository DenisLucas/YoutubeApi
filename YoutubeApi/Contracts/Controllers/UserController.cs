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
        public async Task<IActionResult> CreateUserAsync([FromBody] RegistrateUserCommand request)
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
        public async Task<IActionResult> GetPassword(string user)
        {
            var query = new GetUserQuery(user);
            var User = await _mediator.Send(query); 
            return Ok(User);
        }

        [HttpDelete(ApiRoutes.user.DeleteUser)]
        public async Task<IActionResult> DeleteUser(string user,string password)
        {
            var query = new DeleteUserCommand(user,password);
            var User = await _mediator.Send(query);
            if (User)
            {
                return NoContent();
            }
            return BadRequest();
        }


    }
}
