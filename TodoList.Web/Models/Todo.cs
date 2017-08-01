using System;

namespace TodoApp.Web.Controllers
{
    public class Todo
    {
        public Todo()
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
        
    }
}