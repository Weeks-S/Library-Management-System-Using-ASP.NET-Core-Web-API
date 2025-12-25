using System.IdentityModel.Tokens.Jwt;
using LibraryManagement.DTOs;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService service) : ControllerBase
{
    private readonly AuthService _service = service;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        JwtSecurityToken token;
        try
        {
            token = await _service.Login(dto);
        }
        catch (Exception e)
        {
            return Unauthorized(e);
        }

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
