using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoWeb.Models;

namespace ToDoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoTasksDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ToDoTasksDbContext toDoTasksDbContext)
        {
            _logger = logger;
            _dbContext = toDoTasksDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ToDoTasks()
        {
            var toDoTasks = _dbContext.Tasks.ToList();
            return View(toDoTasks);
        }

        public IActionResult CrudOperations(int? Id)
        {
            return View();
        }

        public IActionResult CrudOperationsForm(ToDoTask toDoTask)
        {
             _dbContext.Tasks.Add(toDoTask);

            _dbContext.SaveChanges();

            return RedirectToAction("ToDoTasks");
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
