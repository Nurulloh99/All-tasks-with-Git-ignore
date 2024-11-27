using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class RestaurantService_With_Connection
{
    private List<Restaurant_With_Connection> ListedRestaurants;

    public RestaurantService_With_Connection()
    {
        ListedRestaurants = new List<Restaurant_With_Connection>();
    }


    public Restaurant_With_Connection AddRestaurant(Restaurant_With_Connection restaurant)
    {
        restaurant.Id = Guid.NewGuid();

        ListedRestaurants.Add(restaurant);
        return restaurant;
    }


    public Restaurant_With_Connection GetById(Guid restaurantID)
    {
        foreach(var rest in ListedRestaurants)
        {
            if(rest.Id == restaurantID)
            {
                return rest;
            }
        }
        return null;
    }



    public List<Restaurant_With_Connection> GetAllRestaurants()
    {
        return ListedRestaurants;
    }



    public bool DeleteRestaurant(Guid restaurantId)
    {
        var foundRestaurant = GetById(restaurantId);

        if(foundRestaurant is null)
        {
            return false;
        }

        ListedRestaurants.Remove(foundRestaurant);
        return true;
    }



    public bool UpdateRestaurant(Guid restaurantId, Restaurant_With_Connection newRestaurant)
    {
        var foundRestaurant = GetById(restaurantId);

        if(foundRestaurant is null)
        {
            return false;
        }

        var index = ListedRestaurants.IndexOf(foundRestaurant);
        ListedRestaurants[index] = newRestaurant;
        return true;
    }





    public Restaurant_With_Connection GetTopRatedRestaurant()
    {
        var topRestaurant = new Restaurant_With_Connection();

        foreach(var rest in ListedRestaurants)
        {
            if(rest.Rating > topRestaurant.Rating)
            {
                topRestaurant = rest;
            }
        }
        return topRestaurant;
    }



    









}
