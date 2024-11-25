using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Restaurant_service
{

    private List<Restaurant> ListedRestaurants;

    public Restaurant_service()
    {
        ListedRestaurants = new List<Restaurant>();
    }






    public Restaurant AddRest(Restaurant restaurant)
    {
        restaurant.Id = Guid.NewGuid();

        ListedRestaurants.Add(restaurant);
        return restaurant;
    }




    public Restaurant GetById(Guid restID)
    {
        foreach(var restaurant in ListedRestaurants)
        {
            if(restaurant.Id == restID)
            {
                return restaurant;
            }
        }
        return null;
    }



    public bool DeleteRestaurant(Guid resID)
    {
        var checkResID = GetById(resID);

        if(checkResID is null)
        {
            return false;
        }

        ListedRestaurants.Remove(checkResID);
        return true;
    }




    public bool UpdatingRestaurant(Guid oldRestaurantID, Restaurant newRestaurant)
    {
        var updatingRestaurantID = GetById(oldRestaurantID);

        if(updatingRestaurantID is null)
        {
            return false;
        }

        var index = ListedRestaurants.IndexOf(updatingRestaurantID);
        ListedRestaurants[index] = newRestaurant;
        return true;
    }



    public List<Restaurant> GetAllRestaurants()
    {
        return ListedRestaurants;
    }




    /// ==========================================================================================
    


    public List<Food> GetAllFoodsByNation(string nation)
    {
        var foodsOfService = new Food_service();
        var listOfFoods = foodsOfService.GetAllFood();
        var listedNationFoods = new List<Food>();

        foreach (var food in listOfFoods)
        {
            if(food.NationOfFood == nation)
            {
                listedNationFoods.Add(food);
            }
        }
        return listedNationFoods;
    }







    



    


     

    













    



}
