using Microsoft.AspNetCore.Mvc;
using Persons.Application.Common.Exceptions;
using Persons.Application.Common.PaginationQuery;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Queries;
using Persons.Domain.BaseResponses;
using Swashbuckle.AspNetCore.Annotations;

namespace Persons.API.Controllers.Person
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : BaseController
    {
        [HttpGet]
        [SwaggerOperation(
        Summary = "Gets Person in the database")]
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
          Summary = "Creates a new Person")]
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Deletes user")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeletePersonCommand(id)
            {
                Id = id
            };

            var result = await Mediator.Send(command);
            return Ok(BaseResponse.Deleted(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
          Summary = "Updates existing Person")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdatePersonCommand command)
        {
            try
            {
                command.Id = id;
                var result = await Mediator.Send(command);
                return Ok(BaseResponse.Updated(result));
            }
            catch (NotFoundException) { throw; }

            catch (Exception ex)
            {
                return BadRequest(BaseResponse.BadRequest(ex.Message));
            }
        }
    }
}
