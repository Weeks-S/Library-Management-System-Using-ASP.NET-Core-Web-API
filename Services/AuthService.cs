using System.IdentityModel.Tokens.Jwt;
using LibraryManagement.Data;
using LibraryManagement.DTOs;
using LibraryManagement.Security;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services;

public class AuthService(AppDbContext context, JwtTokenGenerator jwtTokenGenerator)
{
    private readonly AppDbContext _context = context;

    private readonly JwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<JwtSecurityToken> Login(LoginDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            throw new Exception("Invalid Credentials!");

        return await _jwtTokenGenerator.GenerateToken(user);
    }
}
