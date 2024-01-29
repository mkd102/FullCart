using InterfaceService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        //[HttpPost]
        //public User Post([FromBody] User user)
        //{
        //    return this._userService.CreateUser(user);
        //}


        [HttpPost]
        public HttpResponseMessage Post([FromBody] IEnumerable<User> formData)
        {
            // Formdata collection made it a enumerator
          //  IEnumerator<KeyValuePair<string,
            //    string>> k = formData.GetEnumerator();
            // moved to next position
          //  k.MoveNext();
            // took the current value put in key value pair
          //  KeyValuePair<string, string> c = k.Current;
            // key is the data 
            // its moved to a string
           // string str = c.Key; // reading 

            // string data in to a
            // proper JSON object
            //JArray json = JArray.Parse(str);

            List<User> custs = formData.ToList();

            foreach (var cust in custs)
            {
               var re= this._userService.CreateUser(cust);
                if (re == null)
                    return null;
            }
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            return httpResponseMessage;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
