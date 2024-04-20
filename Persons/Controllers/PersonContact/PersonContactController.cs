using Microsoft.AspNetCore.Mvc;
using Persons.Application.Common.PaginationQuery;
using Persons.Application.PersonContactEntity.Commands;
using Persons.Application.PersonContactEntity.Queries;
using Persons.Domain.BaseResponses;
using Swashbuckle.AspNetCore.Annotations;

namespace Persons.API.Controllers.PersonContact
{
    [Route("api/Contact")]
    [ApiController]
    public class PersonContactController : BaseController
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets Contact")]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                var query = new GetFilteredPersonContactQuery(paginationQuery);
                var result = await Mediator.Send(query);
                return Ok(BaseResponse.Ok(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        [SwaggerOperation(
          Summary = "Creates a new Contact")]
        public async Task<IActionResult> Post([FromBody] CreatePersonContactCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }

    }
}
