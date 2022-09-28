using System.Security.Cryptography;
using Application.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Invoicify.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public static User user = new User();

    [HttpPost("[action]")]
    public async Task<ActionResult<User>> RegisterUser(AuthDto authDto)
    {
          CreatePasswordHash(authDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

          user.Username = authDto.Username;
          user.PasswordHash = passwordHash;
          user.PasswordSalt = passwordSalt;
          // have to add rules
          return Ok(user);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<string>> Login(AuthDto request)
    {
        if (user.Username != request.Username)
        {
            
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}