﻿using CMS.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS.Data
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        //SymmetricSecuirtkey is the type of encryption where only one key as the
        // secret key which we are going to store on our server is used to both encrypt and
        // decrypt our singnature in the token
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            // claim is the bit of information about the user 
            //its could be a user might have a date of birth
            // and they would claim like date of birth is less
            // or user has email they are claiming their email is less
            //type of claim is jwt registr clam
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };
            // these calims are inside the token  are going to able to decoded by the client
            // we will not put sensitive information here
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,
                Issuer = _config["Token:Issuer"]

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }
}
