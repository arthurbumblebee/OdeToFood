using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData data;

        public RestaurantsController(IRestaurantData data)
        {
            this.data = data;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = data.GetAllRestaurants();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = data.GetRestaurant(id);
            if (model == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound");
            }
            return View(model);
        }
    }
}