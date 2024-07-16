namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = ("admin,superadmin"))]
    public class SongsController(ISongService _songService) : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? page, int? limit)
        {
            int currentPage = page ?? 1;
            int currentLimit = limit ?? 10;

            var (data, paginationMetadata) = await _songService.GetPaginatedSongs(currentPage, currentLimit);

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
            var existingSong = await _songService.GetSongById(id);
            if (existingSong == null)
                return NotFound(new { message = "song not found" });

            return Ok(existingSong);
        }

        [HttpGet("featured")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedSongs(int? page, int? limit)
        {
            int currentPage = page ?? 1;
            int currentLimit = limit ?? 10;
            var (data, paginationMetadata) = await _songService.GetFeaturedSongs(currentPage, currentLimit);
            return Ok(new
            {
                data,
                pagination = paginationMetadata
            });
        }

        [HttpGet("latest")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestSongs(int? page, int? limit)
        {
            int currentPage = page ?? 1;
            int currentLimit = limit ?? 10;
            var (data, paginationMetadata) = await _songService.GetLatestSongs(currentPage, currentLimit);
            return Ok(new
            {
                data,
                pagination = paginationMetadata
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSongDto req)
        {
            try
            {
                var newSong = await _songService.CreateSong(req);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Song created successfully",
                    data = newSong
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to create song" });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateSongDto req)
        {
            try
            {
                var updatedSong = await _songService.UpdateSong(id, req);
                if (updatedSong == null)
                    return NotFound(new { message = "Song not found" });

                return Ok(new { message = "Song updated Successfully", data = updatedSong });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update song" });

            }
        }

        [HttpPatch("{id}/toggle-featured")]
        public async Task<IActionResult> ToggleFeatured(int id)
        {
            var toggledSong = await _songService.ToggleFeaturedSong(id);
            if (toggledSong == null)
                return NotFound(new { message = "song not found" });

            return Ok(new { message = "Song feature status toggled successfully", isFeatured = toggledSong });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedSong = await _songService.DeleteSong(id);
            if (!deletedSong)
                return NotFound(new { message = "song not found" });

            return Ok(new { message = "song deleted successfully" });
        }
    }
}