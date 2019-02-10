using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todoListBackEnd.Models;

namespace todoListBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        public TodoListController() { }

        // GET api/todolist
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/todolist/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/todolist
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/todolist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/todolist/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}