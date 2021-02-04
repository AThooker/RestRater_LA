using RestaurantRaterLA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterLA.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _ctx = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_ctx.Restaurants.ToList());
        }

        //GET: Restaurant Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restaurant Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }
            _ctx.Restaurants.Add(restaurant);
            if(_ctx.Restaurants.Add(restaurant).RestaurantID == 0)
            {
                //CHANGES MADE RIGHT HERE
                return HttpNotFound();
            }
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant rst = _ctx.Restaurants.Find(id);
            if(rst == null)
            {
                return HttpNotFound();
            }
            return View(rst);
        }

        //POST: Restaurant Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var rest = _ctx.Restaurants.Find(id);
            _ctx.Restaurants.Remove(rest);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant Update
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rest = _ctx.Restaurants.Find(id);
            if(rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }

        //POST: Restaurant Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(!ModelState.IsValid)
            {
                return View(restaurant);
            }
            _ctx.Entry(restaurant).State = EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant Details
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rest = _ctx.Restaurants.Find(id);
            if(rest == null)
            {
                return HttpNotFound();
            }
            return View(rest);
        }
    }
}