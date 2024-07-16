namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,superadmin")]
    public class ArtistsController(IArtistService _artistService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? page, int? limit)
        {
            var currentPage = page ?? 1;
            var currentLimit = limit ?? 10;
            var (data, paginationMetadata) = await _artistService.GetArtistsAsync(currentPage, currentLimit);
            return Ok(new
            {
                data,
                pagination = paginationMetadata
            });
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var artist = await _artistService.GetArtistByIdAsync(id);
                return Ok(artist);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateArtistDto req)
        {
            try
            {
                var newArtist = await _artistService.CreateArtistAsync(req);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Artist created successfully",
                    data = newArtist
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to create artist" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateArtistDto req)
        {
            try
            {
                var updatedArtist = await _artistService.UpdateArtistAsync(id, req);
                return Ok(new
                {
                    message = "Artist updated successfully",
                    data = updatedArtist,
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update artist" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _artistService.DeleteArtistAsync(id);
                return Ok(new { message = "Artist deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to delete artist" });
            }
        }
    }
}
