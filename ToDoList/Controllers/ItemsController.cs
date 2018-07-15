using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListDbContext db = new ToDoListDbContext();

        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }
    }
}