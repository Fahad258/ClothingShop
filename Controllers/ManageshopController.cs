using clothingshopproject.Database;
using clothingshopproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clothingshopproject.Controllers
{
    [Authorize]
    public class ManageshopController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ManageshopController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Clothingshop> objList = _db.Clothingshop;
            return View(objList);
        }
        //Get create
        public IActionResult Create()
        {
           ViewBag.Size = new List<string>() { "S", "L" ,"M","XL","XXL" };

            return View();
        }
        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clothingshop obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clothingshop.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //Get Edit
        public IActionResult Edit(int? Id)
        {
            ViewBag.Size = new List<string>() { "S", "L", "M", "XL", "XXL" };
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj = _db.Clothingshop.Find(Id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Clothingshop obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clothingshop.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Clothingshop.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletepost(int? Id)

        {
            var obj = _db.Clothingshop.Find(Id);
            if (obj==null)
            {
                return NotFound();
            }
            
                _db.Clothingshop.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           

            
        }
    }
}
