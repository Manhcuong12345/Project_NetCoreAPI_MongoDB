using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Common;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;   
        // GET: api/<AuthsController>

        public AuthsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //  return new string[] { "value1", "value2" };
        //}

        // GET api/<AuthsController>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        //}

           [HttpPost("users")]
            public async Task<IActionResult> CreateUser([FromBody] Users user)
            {
                if (!ModelState.IsValid)
                {
                   return BadRequest();
               }
              
            //Ma hoa password
             user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
             var userData = await _authRepository.CreateAsync(user);

            return Ok(userData);
            }

        // POST api/<AuthsController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthsDto user)
        {
            var userLogin = await _authRepository.LoginUser(user.Email);

            if(userLogin == null) return BadRequest(new {message = "Invalid Email"});
            
            if(!BCrypt.Net.BCrypt.Verify(user.Password, userLogin.Password))
            {
                return BadRequest(new { message = "Invalid Password" });
            }

            if (userLogin != null)
            {
                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                                    .AddSubject(user.Email)
                                    .AddIssuer("issuerTest")
                                    .AddAudience("bearerTest")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(1)
                                    .Build();
               // var response = new AuthsDto
               // {
                //    Id = user.Id,
                   // Email = user.Email
               // };

                return Ok(new { jwt = token.Value});

            }
            else
                return Unauthorized($"Unauthorized");
        }

        // PUT api/<AuthsController>/5
       // [HttpPut("{id}")]
       // public void Put(int id, [FromBody] Users user)
       // {
        //}

        // DELETE api/<AuthsController>/5
       // [HttpDelete("{id}")]
       // public void Delete(int id)
       // {
       // }
    }
}
