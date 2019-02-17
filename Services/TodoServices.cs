using System.Collections.Generic;
using System.Linq;
using todoListBackEnd.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class TodoServices
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoServices(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TodoListDBConnection"));
            var database = client.GetDatabase("todolist");
            _todos = database.GetCollection<Todo>("todo");
        }

        public List<Todo> Get()
        {
            return _todos.Find(todo => true).ToList();
        }

        public Todo Get(string id)
        {
            return _todos.Find<Todo>(book => book.Id == id).FirstOrDefault();
        }

        public Todo Create(Todo book)
        {
            _todos.InsertOne(book);
            return book;
        }

        public void Update(string id, Todo bookIn)
        {
            _todos.ReplaceOne(book => book.Id == id, bookIn);
        }

        public void Remove(Todo bookIn)
        {
            _todos.DeleteOne(book => book.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _todos.DeleteOne(book => book.Id == id);
        }
    }
}
