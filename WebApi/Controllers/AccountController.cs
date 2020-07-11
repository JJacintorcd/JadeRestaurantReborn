using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recodme.Rd.JadeRest.DataLayer.UserData;

namespace Recodme.Rd.JadeRest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly IConfiguration _config;

        //public AccountController(IConfiguration config)
        //{
        //    _config = config;
        //}

        //[HttpGet]
        //public ActionResult<string> Login()
        //{
        //    var mockUser = new JadeUser(Guid.NewGuid());
        //    mockUser.Email = "notfakeatall@trustme.com";
        //    mockUser.PasswordHash = "12345";
        //    return GenerateJsonWebToken(mockUser);
        //}

        //[HttpGet("Secret")]
        //[Authorize]
        //public ActionResult<string> Secret()
        //{
        //    return "it's free real estate";
        //}

        //private string GenerateJsonWebToken(JadeUser user)
        //{
        //    var jwtKey = _config["Jwt:key"];
        //    var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
        //    var key = new SymmetricSecurityKey(keyBytes);
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var issuer = _config["Jwt:Issuer"];
        //    var audience = _config["Jwt:Audience"];
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email)
        //    };
        //    var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}