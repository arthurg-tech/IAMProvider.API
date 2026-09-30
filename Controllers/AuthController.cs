using IamProvider.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IamProvider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null) return StatusCode(500, new { Message = "Usuário já existe!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return StatusCode(500, new { Message = "Erro ao criar usuário." });

            return Ok(new { Message = "Usuário criado com sucesso!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = token.ValidTo });
            }
            return Unauthorized();
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
        {
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
                return Ok(new { Message = "Role criada com sucesso!" });
            }
            return BadRequest(new { Message = "Role já existe." });
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return NotFound(new { Message = "Usuário não encontrado." });

            if (await _roleManager.RoleExistsAsync(model.RoleName))
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);
                return Ok(new { Message = "Role atribuída ao usuário com sucesso!" });
            }
            return BadRequest(new { Message = "Role não existe." });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            return new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}