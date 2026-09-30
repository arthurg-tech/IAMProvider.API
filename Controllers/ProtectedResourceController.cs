using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IamProvider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Exige um token JWT válido para qualquer rota desta classe
    public class ProtectedResourceController : ControllerBase
    {
        [HttpGet("dados-publicos")]
        [AllowAnonymous] // Exceção: qualquer um pode acessar sem token
        public IActionResult GetPublicData()
        {
            return Ok(new { Message = "Esta rota é pública e não exige autenticação." });
        }

        [HttpGet("dados-usuario")]
        [Authorize(Roles = "User, Admin")] // Exige a role User OU Admin
        public IActionResult GetUserData()
        {
            return Ok(new { Message = "Acesso autorizado: O seu token contém a permissão de Usuário." });
        }

        [HttpGet("dados-admin")]
        [Authorize(Roles = "Admin")] // Exclusivo para Admins
        public IActionResult GetAdminData()
        {
            return Ok(new { Message = "Acesso autorizado: O seu token contém privilégios de Administrador." });
        }
    }
}