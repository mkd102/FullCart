using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TokenWebApi.TokenCreation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenCreation _tokenCreation;
        public TokenController(ITokenCreation tokenCreation) { this._tokenCreation = tokenCreation; }
        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(string email,string password)
        {
            return string.Empty;
        }

        // POST api/<TokenController>
        [HttpPost]
        public string Post([FromBody] IEnumerable<Login> value)
        {
            List<Login> custs = value.ToList();

            foreach (var cust in custs)
            {
                var re =this._tokenCreation.CreateToken(cust.EmailId, cust.Password); ;
                if (re == null)
                    return null;
                return re;
            }

            return null;

        }

        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TokenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
