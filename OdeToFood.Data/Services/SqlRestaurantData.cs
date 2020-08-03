using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext database;

        public SqlRestaurantData(OdeToFoodDbContext database)
        {
            this.database = database;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            database.Restaurants.Add(restaurant);
            database.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            var restaurant = database.Restaurants.Find(id);
            database.Restaurants.Remove(restaurant);
            database.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            //return database.Restaurants
            return from r in database.Restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurant(int id)
        {
            return database.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            //var r = GetRestaurant(restaurant.Id);
            //r.Name = "";
            //database.SaveChanges();

            var entry = database.Entry(restaurant);
            entry.State = EntityState.Modified;
            database.SaveChanges();
        }
    }
}
