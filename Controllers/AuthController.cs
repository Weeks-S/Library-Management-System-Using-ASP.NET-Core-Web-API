using System.Numerics;
using System.Security.Claims;
using LibraryManagement.Data;
using LibraryManagement.DTOs;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService service, UserService userService) : ControllerBase
{
    private readonly AuthService _service = service;
    private readonly UserService _userService = userService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        string token;
        try
        {
            token = await _service.Login(dto);
        }
        catch (Exception e)
        {
            return Unauthorized(e);
        }

        return Ok(new { token });
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMe()
    {
        var user = new UserResponseDto();
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID not found in token claims.");
        }
        else if (int.TryParse(userId, out int id))
        {
            var getUser = await _userService.GetByIdAsync(id);
            if (getUser == null)
            {
                return NotFound("User Not Found!");
            }
            user.Email = getUser.Email;
            user.Id = getUser.Id;
            user.Name = getUser.Name;
        }

        return Ok(user);
    }
}
