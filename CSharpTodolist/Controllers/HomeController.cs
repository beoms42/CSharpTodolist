using CSharpTodolist.Models;
using CSharpTodolist.Service;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;

namespace CSharpTodolist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CRUDService _CRUDService = new CRUDService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreateTodo()
        {
            return View("TodoCreate");
        }

        [HttpPost]
        public IActionResult CreateTodoAction(TodoList todoList)
        {
            var s = _CRUDService.Create(todoList);

            _logger.LogError("create result = "+s);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTodo(int id)
        {
            _CRUDService.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateView(int id)
        {
            TodoList todo = _CRUDService.ConvertDataTableToList(_CRUDService.FindOne(id)).FirstOrDefault();
            return View("UpdateView", todo);
        }

        [HttpPost]
        public IActionResult UpdateAction(TodoList todolist)
        {
            _logger.LogError(todolist.ToString());  
            _CRUDService.Update(todolist);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var s =_CRUDService.Read();

            return View(_CRUDService.ConvertDataTableToList(s));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
