using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        { 
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Arthur's Pizza", Cuisine=CuisineType.Italian},
                new Restaurant{Id=2, Name="Makumbi's Paris Delight", Cuisine=CuisineType.French},
                new Restaurant{Id=2, Name="Yawe's Chinatown", Cuisine=CuisineType.China},

            };

        }

        public void AddRestaurant(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurant(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return restaurants.OrderBy(restaurants => restaurants.Name);
        }

        public Restaurant GetRestaurant(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var existing = GetRestaurant(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
