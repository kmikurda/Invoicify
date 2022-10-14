using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Commands;
using Application.Dto;
using Application.Interfaces.Read;
using Common.CQRS.Commands;
using Common.Globals;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Application.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery,AuthToken>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly ILogger<LoginQueryHandler> _logger;

    public LoginQueryHandler(IUserReadRepository userReadRepository, ILogger<LoginQueryHandler> logger)
    {
        _userReadRepository = userReadRepository;
        _logger = logger;
    }

    public async Task<AuthToken> Handle(LoginQuery query, CancellationToken ct)
    {
        try
        {
            Log.Information("asd");

           // var user = _userReadRepository.FindBy(x => x.Username == query.UserName).FirstOrDefault();
           var user = new User()
           {
               Username = "asd",
               Password = "asd"
           };
            if (user == null)
            {
                _logger.LogError("User not exist");
                throw new Exception("User not exist");
            }
            if (user.Password != query.Password)
            {
                _logger.LogError("Incorrect password");
                throw new Exception("Incorrect password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, UserRoleEnum.DevAdmin.ToString())
            };
            
            

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalVar.SecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new AuthToken()
            {
                TokenString = tokenString
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw new Exception(e.Message);
        }
    }
}