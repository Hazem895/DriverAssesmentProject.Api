using AssesmentProject.Domain.DriversDomain;
using AssesmentProject.Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssesmentProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ICrudCommandsRepository<Driver> _repo;

        public DriversController(ICrudCommandsRepository<Driver> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> SelectRequest(Guid? Id = null)
        {
            try
            {
                return Ok(await _repo.ReadAll());
            }
            catch (Exception ex)
            {
                return BadRequest(Enumerable.Empty<Driver>());
            }
        }


        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> SelectByIdRequest(Guid Id)
        {
            try
            {
                return Ok(await _repo.ReadById(Id));
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(Driver InputData)
        {
            try
            {
                await _repo.Create(InputData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id:Guid}")]
        public async Task<IActionResult> UpdateRequest([FromBody]Driver InputData, Guid Id)
        {
            try
            {
                await _repo.Update(InputData, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> DeleteRequest(Guid Id)
        {
            try
            {
                await _repo.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
