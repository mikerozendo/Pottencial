using Microsoft.IdentityModel.Tokens;
using Pottencial.Infraestructure.CrossCutting.JWT.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Pottencial.Infraestructure.CrossCutting.JWT;

public  class JwtGenerator :  IJwtGenerator
{
    private readonly JwtConfiguration _jwtConfiguration;

    public JwtGenerator()
    {
        _jwtConfiguration = new();
    }

    public string GerarTokenJWT()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: _jwtConfiguration.Issuer,
            audience: _jwtConfiguration.Audience,
            expires: _jwtConfiguration.ExpiresIn,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}
