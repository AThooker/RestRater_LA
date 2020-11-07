using RestaurantRaterLA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}