using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Core.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Services
{
    public class TokenService : ITokenService
    {
        public IConfiguration Configuration { get; }

        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<string> CreateToken(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            // private claims
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Gender, user.Gender),
            };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            // secret key
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));

            // token
            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:ValidIssuer"],
                audience: Configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(Configuration["JWT:DurationInDays"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
