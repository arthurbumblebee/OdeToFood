using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.API
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData data;

        public RestaurantsController(IRestaurantData data)
        {
            this.data = data;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = data.GetAllRestaurants();
            return model;
        }
    }
}
