using System.Security.Cryptography;
using System.Text;
using Application.Commands;
using Application.Dto;
using Common.CQRS.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoicify.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private static readonly User user = new User();
    private readonly IQueryBus _queryBus;


    public AuthController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<User>> RegisterUser(AuthDto authDto)
    {
          CreatePasswordHash(authDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

          user.Login = authDto.Username;
        
          // have to add rules
          return Ok(user);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginQuery loginQuery)
    {
        var result = await _queryBus.Send<LoginQuery,AuthToken>(loginQuery);
        return !string.IsNullOrEmpty(result.TokenString) ? Ok(result) : NotFound();
    }

    [HttpGet]
    [Authorize(Roles = "DevAdmin")]
    public string WriteSomething()
    {
        return "RETURNED!";
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}