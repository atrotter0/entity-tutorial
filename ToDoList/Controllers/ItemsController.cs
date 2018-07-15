using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListDbContext db = new ToDoListDbContext();
        public IActionResult Index()
        {
            List<Item> model = db.Items.ToList();
            return View(model);
        }
    }
}