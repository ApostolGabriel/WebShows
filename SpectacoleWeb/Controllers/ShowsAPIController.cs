using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpectacoleWeb.Business_Logic;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsAPIController : ControllerBase
    {
        private readonly ShowService _showService;

        public ShowsAPIController(ShowService showService)
        {
            _showService = showService;
        }

        //Get : api/ShowsAPI/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            var shows = await _showService.Get();
            return Ok(shows);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteShow(int id)
        {
            try
            {
                _showService.Delete(id);
                await _showService._unitOfWork.Complete();
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
