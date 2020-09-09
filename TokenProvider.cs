using Fuela.DBContext;
using Lubricants.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lubricants
{
    public class TokenProvider
    {
        ApplicationDBContext _context;

        public TokenProvider(ApplicationDBContext context)
        {
            _context = context;
        }

        public string LoginUser(string strEmail, string password)
        {
            string username = strEmail;
            string pass = password;

            var user = _context.c_Users.SingleOrDefault(x => x.strUserId == username && x.strPassword == pass);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return null;

            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            var JWToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            var strusername = user.Full_name;
            return token;
        }
        private IEnumerable<Claim> GetUserClaims(c_Users user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.strEmail);
            claims.Add(_claim);

            _claim = new Claim(ClaimTypes.Role, user.strRole);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }
    }
}
