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

        [HttpGet("/items")]
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }

        [HttpGet("/items/{id}")]
        public IActionResult Details(int id)
        {
            Item item = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(item);
        }

        [HttpGet("/items/new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/items/new")]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/items/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Item item = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(item);
        }

        [HttpPost("/items/{id}/edit")]
        public IActionResult Edit(int id, Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("/items/{id}/delete")]
        public IActionResult Delete(int id)
        {
            Item item = db.Items.FirstOrDefault(items => items.ItemId == id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}