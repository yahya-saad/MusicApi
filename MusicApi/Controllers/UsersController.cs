namespace MusicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(ApplicationDbContext _context, JwtService jwtService) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto req)
        {

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
            if (existingUser is not null)
                return Conflict(new { message = "Email address already in use" });

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);

            var newUser = new User
            {
                Name = req.Name,
                Email = req.Email,
                Password = passwordHash,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully", data = newUser });

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto req)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
                return Unauthorized(new { message = "Invalid email or password" });

            var token = jwtService.GenerateJwtToken(user);

            return Ok(new { AccessToken = token });
        }

        [HttpPatch]
        [Route("[action]/{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> ChangeRole(int id, string role)
        {
            var validRoles = new[] { "admin", "user", "superadmin" };

            if (string.IsNullOrEmpty(role) || !validRoles.Contains(role, StringComparer.OrdinalIgnoreCase))
                return BadRequest(new { message = "Invalid role. Role must be one of: User, Admin, SuperAdmin." });

            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return NotFound(new { message = "User not found." });

            user.Role = role.ToLower();
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Role changed successfully to {role}.", data = user });
        }

        [HttpGet("users")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }



    }
}
