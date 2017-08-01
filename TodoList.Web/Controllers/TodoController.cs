using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        public static IList<Todo> Todos = new List<Todo>();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return JsonSuccess(Todos);
        }
        public JsonResult Add(string text)
        {
            var newTodo = new Todo() { Text = text};
            Todos.Add(newTodo);
            newTodo.Modified = DateTime.Now;
            return JsonSuccess(newTodo, "Success.");
        }
        public JsonResult Update(Guid? id, string text)
        {
            var todo = Todos.SingleOrDefault(x => x.Id == id);
            if (todo == null)
                return JsonError("Update Error!");
            todo.Text = text;
            todo.Modified = DateTime.Now;
            return JsonSuccess(todo, "Update Succes.");
        }
        //public JsonResult Delete(Guid? id)
        //{
        //    var todo = Todos.SingleOrDefault(x => x.Id == id);
        //    if (todo == null)
        //        return JsonError("Delete Error!");
        //    Todos.Remove(todo);
        //    return JsonSuccess(null, "Delete Succses.");
        //}

        public JsonResult JsonSuccess(dynamic data, string message = "")
        {
            return Json(new
            {
                IsSuccess = true,
                Message = message,
                Data = data
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonError(string message)
        {
            return Json(new
            {
                IsSuccess = false,
                Message = message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}