using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Commands;
using Application.Interfaces.Read;
using Common.CQRS.Commands;
using Common.Globals;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Application.CommandHandlers;

public class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly ILogger _logger;

    public LoginCommandHandler(IUserReadRepository userReadRepository, ILogger logger)
    {
        _userReadRepository = userReadRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Handler(LoginCommand command, CancellationToken ct)
    {
        try
        {
            _logger.Information("asd");

            var user = _userReadRepository.FindBy(x => x.Username == command.UserName).FirstOrDefault();
            if (user == null)
            {
                _logger.Error("User not exist");
                throw new Exception("Ni ma takiego usera");
            }
            if (user.Password != command.Password)
            {
                _logger.Error("Incorrect password");
                throw new Exception("Incorrect password");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalVar.SecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}