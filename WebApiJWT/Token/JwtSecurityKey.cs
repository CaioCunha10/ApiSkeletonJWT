using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiJWT.Token
{
    public class JwtSecurityKey
    {
        public DateTime ValidTo { get; internal set; }

        public static SymmetricSecurityKey Create (string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }

        public static implicit operator JwtSecurityKey(JwtSecurityToken v)
        {
            throw new NotImplementedException();
        }
    }
}
