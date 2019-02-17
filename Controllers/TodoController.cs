using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using todoListBackEnd.Models;

namespace todoListBackEnd.Controllers
{
    [Route("api/v1/[controller]")]
    public class TodoController : Controller
    {

         private readonly TodoServices _todoServices;

        public TodoController(TodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        [HttpGet("")]
        public ActionResult<List<Todo>> Gets()
        {
            return _todoServices.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        public ActionResult<Todo> GetById(string id)
        {
            var Todo = _todoServices.Get(id);

            if (Todo == null)
            {
                return NotFound();
            }

            return Todo;
        }

        [HttpPost("")]
        public ActionResult<Todo> Create([FromBody] Todo todo) 
        {   
            _todoServices.Create(todo);

            return CreatedAtRoute("GetTodo", new { id = todo.Id.ToString() }, todo);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Todo TodoIn)
        {
            var book = _todoServices.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _todoServices.Update(id, TodoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _todoServices.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _todoServices.Remove(book.Id);

            return NoContent();
        }
    }
}