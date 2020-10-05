using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Common.Controllers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualBasic;
using CleanArchitecture.US.Common;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.US.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : APIBaseController
    {

        private IAdminApplication _adminApplication { get; }
        private IUserApplication _userApplication { get; }

        public AdminController(IConfiguration configuration, ILogger<AdminController> logger, IAdminApplication adminApplication, IUserApplication userApplication)
            : base(configuration, logger)
        {
            _adminApplication = adminApplication;
            this._userApplication = userApplication;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        //[Authorize()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<Admin> Get(int id)
        {
            //  var res = HttpContext.Items["UserID"];
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var userId = claims.Claims.FirstOrDefault(x => x.Type == Constant.UserId);
            var result = await _adminApplication.GetById(id);
            return result;
        }
      
        [HttpGet("User/{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _userApplication.GetById(id);
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpGet("SignIn/{id}")]
        public async Task<IActionResult> SignIn(int id)
        {
            var result = await _adminApplication.GetById(id);
            string tokenResult = string.Empty;
            if (result != null)
            {
                var Claims = new ClaimsIdentity(new Claim[]
                              {
                                    new Claim("email", "us@us.com"),
                                    new Claim(Constant.UserId, id.ToString())
                               });

                var tokenHandler = new JwtSecurityTokenHandler();

                var encryptionkey = Configuration["Jwt:Encryptionkey"];
                var key = Encoding.ASCII.GetBytes(encryptionkey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = Configuration["Jwt:Issuer"],
                    Subject = Claims,
                    Audience = Configuration["Jwt:Audience"],
                    Expires = DateTime.Now.AddMinutes(Convert.ToDouble(Configuration["Jwt:ExpiryTimeInMinutes"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                tokenResult = tokenHandler.WriteToken(token);
            }
            return Ok(new
            {
                token = tokenResult
            });

            
        }
        
       
    }
}
