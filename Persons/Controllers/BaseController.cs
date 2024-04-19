using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Persons.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

        protected new IActionResult Response(object data)
        {
            return Ok(new
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Data = data,
            });
        }

        protected IActionResult ErrorResponse(Exception exception)
        {
            return BadRequest(new
            {
                Status = HttpStatusCode.BadRequest,
                exception.Message,
            });
        }
    }
}
