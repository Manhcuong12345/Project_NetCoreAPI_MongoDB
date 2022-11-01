//using Microsoft.AspNetCore.Mvc;
//using Project_NetCore_MongoDB.Models;
//using Project_NetCore_MongoDB.Repository.Interface;
//using Project_NetCore_MongoDB.Repository;
//using Project_NetCore_MongoDB.Dto;
//using Project_NetCore_MongoDB.Services.Interface;
//using Newtonsoft.Json.Serialization;
//using System.Runtime.CompilerServices;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Project_NetCore_MongoDB.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RolesController : ControllerBase
//    {
//        private readonly IRolesService _rolesService;
//        private readonly IUsersService _authService;
//        // GET: api/<AuthsController>

//        public RolesController(IRolesService rolesService, IUsersService authService)
//        {
//            _rolesService = rolesService;
//            _authService = authService;
//        }
//        // GET: api/<RolesController>
//        // [HttpGet]
//        //public IEnumerable<string> Get()
//        // {
//        //return new string[] { "value1", "value2" };
//        // }

//        // GET api/<RolesController>/5
//        // [HttpGet("{id}")]
//        // public string Get(int id)
//        // {
//        // return "value";
//        // }

//        // POST api/<RolesController>
//        [HttpPost]
//        public async Task<IActionResult> Create(RolesName roles)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            var data = await _rolesService.CreateAsync(roles);
//            return Ok(data);
//        }

//        //[HttpPost("addUserRole")]
//      //  public async Task<IActionResult> AddToRole(string email,string role)
//       // {
//          //  var emailExist = await _authService.GetByEmail(email);
//            //if (emailExist == null)
//            //{
//               // return BadRequest(new { message = "User does not exist!" });
//           // }

//           // var roleExist = await _rolesService.GetByRole(role);
//            //if (roleExist == null)
//           // {
//               // return BadRequest(new { message = "Role does not exist!" });
//          //  }

//            //var result = await _authService.CreateAsync(role);
//        //}
//        // PUT api/<RolesController>/5
//        // [HttpPut("{id}")]
//        // public void Put(int id, [FromBody] string value)
//        //{
//        //}

//        // DELETE api/<RolesController>/5
//        // [HttpDelete("{id}")]
//        // public void Delete(int id)
//        //{
//        //}
//    }
//}
