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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.US.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : APIBaseController
    {

        private IAdminApplication _adminApplication { get; }
        private IUserApplication _userApplication { get; }
        public AdminController(IConfiguration configuration, IAdminApplication adminApplication, IUserApplication userApplication) {
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
        [HttpGet("{id}")]
        public async Task<Admin> Get(int id)
        {

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

        // DELETE api/<AdminController>/5
       /* [HttpGet("delete/{id}")]
        public async Task Delete(int id)
        {
            var admin = new Admin()
            {
                AdminId = id,
                RowState = EntityState.Deleted
            };
            var user = new User()
            {
                UserId = id,
                RowState = EntityState.Deleted
            };
            //await _adminApplication.Save(admin,false);
            await _adminApplication.DeleteByUserAdmin(admin, user);
        }
        */
    }
}
