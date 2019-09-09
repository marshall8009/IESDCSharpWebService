using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//...
using ToDoWebService.Models;

namespace ToDoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private static int? TodoCount;
        private static Dictionary<int, ToDoItem> Todos;

        public ToDosController()
        {
            if (TodoCount.HasValue == false)
            {
                TodoCount = 0;
            }

            if (Todos == null)
            {
                Todos = new Dictionary<int, ToDoItem>();
            }
        }

        // Get api/values
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> Get()
        {
            if (Todos == null)
            {
                return null;
            }

            return Todos.Values;
        }

        // Post api/values
        [HttpPost]
        public ToDoItem Post([FromBody] ToDoItem value)
        {
            ExceptionsModel.TodoException(Todos);

            ToDoItem todo = new ToDoItem
            {
                Id = TodoCount.Value,
                IsComplete = value.IsComplete,
                Title = value.Title
            };

            if (Todos.TryAdd(TodoCount.Value, todo) == false)
            {
                throw new Exception("Todo already exists.");
            }

            TodoCount++;
            return todo;
        }

        // Put api/values/5
        [HttpPut("{id}")]
        public ToDoItem Put(int id, [FromBody] ToDoItem value)
        {
            ExceptionsModel.TodoException(Todos);

            ExceptionsModel.TodoException(id, value);

            ExceptionsModel.TodoException(Todos, id);

            Todos.Remove(id);
            Todos.Add(id, value);
            return Todos[id];
        }

        // Delete api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ExceptionsModel.TodoException(Todos);

            ExceptionsModel.TodoException(Todos, id);

            Todos.Remove(id);
        }
    }
}