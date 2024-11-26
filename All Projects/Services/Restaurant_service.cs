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
        DataSeed();
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



     public void DataSeed()
 {
     var restaurant1 = new Restaurant
     {
         Id = Guid.NewGuid(),
         Name = "Bahor",
         Location = "Chilonzor 13",
         Description = "A cozy spot offering authentic Japanese sushi and ramen with a modern twist.",
         Opened_Date = DateTime.Now,
         Nation_of_restaurant = "Uzbek"
     };

     var restaurant2 = new Restaurant
     {
         Id = Guid.NewGuid(),
         Name = "Dubay",
         Location = "Oq TEpa",
         Description = "An Italian classic, serving traditional pasta, pizza, and fine wines in a rustic setting.",
         Opened_Date = DateTime.Now,
         Nation_of_restaurant = "Uzbek"
     };

     var restaurant3 = new Restaurant
     {
         Id = Guid.NewGuid(),
         Name = "Birbalo",
         Location = "Uchtepa",
         Description = "An exotic Indian restaurant specializing in flavorful curries, biryanis, and street food.",
         Opened_Date = DateTime.Now,
         Nation_of_restaurant = "Uzbek"
     };

     ListedRestaurants.Add(restaurant1);
     ListedRestaurants.Add (restaurant2);
     ListedRestaurants.Add(restaurant3);
 }




    



    


     

    













    



}
