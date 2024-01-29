using AutoMapper;
using CMS.Data;
using CMS.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CMS.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _config;
        

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto loginRequest)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }


        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

        //    return Ok(token);
        //}
    }
}
