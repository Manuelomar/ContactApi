using Microsoft.AspNetCore.Mvc;
using Persons.Application.Common.PaginationQuery;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Queries;
using Persons.Domain.BaseResponses;
using Swashbuckle.AspNetCore.Annotations;

namespace Persons.API.Controllers.Person
{
    [Route("api/users")]
    [ApiController]
    public class PersonController:BaseController
    {
        [HttpGet]
        [SwaggerOperation(
        Summary = "Gets users in the database")]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                var query = new GetFilteredPersonQuery(paginationQuery);
                var result = await Mediator.Send(query);
                return Ok(BaseResponse.Ok(result));
            }
            catch (Exception ex)
            {
                return BadRequest(BaseResponse.BadRequest(ex.Message));
            }
        }

        [HttpPost]
        [SwaggerOperation(
          Summary = "Creates a new user")]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }
    }
}
