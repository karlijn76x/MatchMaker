using MatchMaker.Interfaces;
using MatchMaker.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LoginController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly IApplicationDbContext _dbContext;
    private readonly PasswordHelper _passwordHelper;

    public LoginController(TokenService tokenService, IApplicationDbContext dbContext, PasswordHelper passwordHelper)
    {
        _tokenService = tokenService;
        _dbContext = dbContext;
        _passwordHelper = passwordHelper;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest login)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == login.Email);
        if (user != null && _passwordHelper.VerifyPassword(user.PasswordHash, login.Password))
        {
            var token = _tokenService.GenerateToken(user.Id.ToString(), user.Email);
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Invalid email or password." });
    }


}
