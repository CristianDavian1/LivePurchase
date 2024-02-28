using System.Security.Claims;
using Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Utils.Security;

public class TokenGenerator
{

    public string GenerarToken(LoginDto model)
    {
        var result =  GetToken(model.UserName);

        return result;
    }

    private string  GetToken(string userName)
    {
        var token = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("AKIAU3S75QKKR6PATVOAFDGCVSGDSDRJHDFHDFHSDTS");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            {
                new Claim(ClaimTypes.Name, userName)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var securityToken = token.CreateToken(tokenDescriptor);
        return token.WriteToken(securityToken);
    }

}

