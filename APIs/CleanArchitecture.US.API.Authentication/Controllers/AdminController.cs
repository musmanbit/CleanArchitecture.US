using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Common;
using CleanArchitecture.US.Common.Controllers;
using CleanArchitecture.US.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.US.API.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : APIBaseController
    {

        private IAdminApplication AdminApplication { get; }
        private IUserApplication UserApplication { get; }

        public AdminController(IConfiguration configuration, ILogger<AdminController> logger, IAdminApplication adminApplication, IUserApplication userApplication)
            : base(configuration, null)
        {
            AdminApplication = adminApplication;
            this.UserApplication = userApplication;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var summaryData = string.Empty;
            var incrementalData = string.Empty;
            return new string[] { summaryData, incrementalData };
        }

        // GET api/<AdminController>/5
        //[Authorize()]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<Admin> Get(int id)
        {
            if (id == 5) throw  new Exception("not found");
            //  var res = HttpContext.Items["UserID"];
            var result = await AdminApplication.GetById(id);
            
            return result;
        }
      
        [HttpGet("User/{id}")]
        public async Task<User> GetUser(int id)
        {
            return await UserApplication.GetById(id);
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
            var result = await AdminApplication.GetById(id);
            string tokenResult = string.Empty;
            if (result != null)
            {
                var claims = new ClaimsIdentity(new Claim[]
                              {
                                    new Claim("email", "us@us.com"),
                                    new Claim(Constant.UserId, id.ToString())
                               });

                var tokenHandler = new JwtSecurityTokenHandler();

                var encryptionKey = Configuration["Jwt:Encryptionkey"];
                var key = Encoding.ASCII.GetBytes(encryptionKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = Configuration["Jwt:Issuer"],
                    Subject = claims,
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
        [HttpGet("InsertAdminaccess")]
        public async Task Insert()
        {

            var admin = new Admin()
            {
                CreatedBy = 5,
                FirstName = DateTime.Now.Second + " - US",
                RowState = EntityState.New
            };

            var user = new User()
            {
                CreatedBy = 5,
                FirstName = DateTime.Now.Second + " - US",
                RowState = EntityState.New
            };
            await AdminApplication.SaveAdminUser(admin, user);
        }


    }
}
