using OdeToFood.Data.Models;
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
        private readonly IRestaurantData database;

        public RestaurantsController(IRestaurantData data)
        {
            this.database = data;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = database.GetAllRestaurants();

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = database.GetRestaurant(id);
            if (model == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //if (String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}



            if (ModelState.IsValid)
            {
                database.AddRestaurant(restaurant);
                return RedirectToAction("Details", new { id=restaurant.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = database.GetRestaurant(id);
            if (model==null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                database.UpdateRestaurant(restaurant);
                return RedirectToAction("Details", new { id=restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = database.GetRestaurant(id);
            if (model==null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            database.DeleteRestaurant(id);
            return RedirectToAction("Index");
        }
    }
}