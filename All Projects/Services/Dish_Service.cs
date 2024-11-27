using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Dish_Service
{

    private List<Dish> ListedDishes;

    public Dish_Service()
    {
        ListedDishes = new List<Dish>();
    }




    public Dish AddDish(Dish addingDish)
    {
        addingDish.Id = Guid.NewGuid();

        ListedDishes.Add(addingDish);
        return addingDish;
    }



    public Dish GetById(Guid dishId)
    {
        foreach(var dish in ListedDishes)
        {
            if(dish.Id == dishId)
            {
                return dish;
            }
        }
        return null;
    }



    public List<Dish> GetAllDishes()
    {
        return ListedDishes;
    }



    public bool DeleteDish(Guid dishId)
    {
        var foundDish = GetById(dishId);

        if(foundDish is null)
        {
            return false;
        }

        ListedDishes.Remove(foundDish);
        return true;
    }



    public bool UpdatedDish(Guid dishID, Dish dish)
    {
        var foundDish = GetById(dishID);
            
        if(foundDish is null)
        {
            return false;
        }

        var index = ListedDishes.IndexOf(foundDish);
        ListedDishes[index] = dish;
        return true;
    }




    public Dish GetMostExpensiveDishByRestaurant(Guid restaurant)
    {
        var mostExpensiveDish = new Dish();

        foreach (var dish in ListedDishes)
        {
            if(dish.RestaurantId == restaurant && dish.Price > mostExpensiveDish.Price)
            {
                mostExpensiveDish = dish;
            }
        }
        return mostExpensiveDish;
    }




    public List<Dish> GetAllDishesUnderPrice(Double price)
    {
        var collectAllDishes = new List<Dish>();

        foreach(var dish in ListedDishes)
        {
            if(dish.Price <= price)
            {
                collectAllDishes.Add(dish);
            }
        }
        return collectAllDishes;
    }



    public Dish SearchDishByName(string dishName)
    {
        var nameOfDish = new Dish();

        foreach(var dish in ListedDishes)
        {
            if(dish.Name == dishName)
            {
                nameOfDish = dish;
                break;
            }
        }
        return nameOfDish;
    }




    public Dish GetAverageDishPriceByRestaurant(int chip, int expensive)
    {
        foreach(var dish in ListedDishes)
        {
            if(dish.Price > chip && dish.Price < expensive)
            {
                return dish;
            }
        }
        return null;
    }














}
