namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,superadmin")]
    public class AlbumsController(IAlbumService _albumService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? page, int? limit)
        {
            var currentPage = page ?? 1;
            var currentLimit = limit ?? 10;
            var (data, paginationMetadata) = await _albumService.GetAllAlbumsAsync(currentPage, currentLimit);
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
            var album = await _albumService.GetAlbumByIdAsync(id);
            if (album == null)
                return NotFound(new { message = "Album not found" });

            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAlbumDto req)
        {
            try
            {
                var createdAlbum = await _albumService.CreateAlbumAsync(req);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    message = "Album created successfully",
                    data = createdAlbum
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to create album" });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAlbumDto req)
        {
            try
            {
                var updatedAlbum = await _albumService.UpdateAlbumAsync(id, req);
                return Ok(new
                {
                    message = "Album updated successfully",
                    data = updatedAlbum,
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update album " });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _albumService.DeleteAlbumAsync(id);
                return Ok(new { message = "Album deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to delete album" });
            }
        }

    }
}
