﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Litmus.Entities;

namespace Litmus.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant newRestaurant);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            _context.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "Tersiguel's"
                },
                new Restaurant()
                {
                    Id = 2,
                    Name = "LJ's and the Kat"
                },
                new Restaurant()
                {
                    Id = 3,
                    Name = "King's Contrivance"
                }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

    }
}
