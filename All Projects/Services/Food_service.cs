using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Food_service
{

    private List<Food> ListedFood;

    public Food_service()
    {
        ListedFood = new List<Food>();
        DataSeed();
    }


    public Food AddFood(Food addingFood)
    {
        addingFood.Id = Guid.NewGuid();

        ListedFood.Add(addingFood);
        return addingFood;
    }



    public Food GetById(Guid foodID)
    {
        foreach(var food in ListedFood)
        {
            if(food.Id == foodID)
            {
                return food;
            }
        }
        return null;
    }


    public bool DeletedFood(Guid foodID)
    {
        var checkingFood = GetById(foodID);

        if(checkingFood is null)
        {
            return false;
        }

        ListedFood.Remove(checkingFood);
        return true;
    }


    public bool UpdatedFood(Guid foodID, Food food)
    {
        var checkingFood = GetById(foodID);

        if(checkingFood is null)
        {
            return false;
        }

        var index = ListedFood.IndexOf(checkingFood);
        ListedFood[index] = food;
        return true;
    }





    public List<Food> GetAllFood()
    {
        return ListedFood;
    }


    /// ==================================================================================================


    public bool AddCommetForFood(Guid IdForComment, string addingComment)
    {
        var findFood = GetById(IdForComment);

        if (findFood is null)
        {
            return false;
        }

        var index = ListedFood.IndexOf(findFood);
        ListedFood[index].CommentOfFood.Add(addingComment);
        return true;
    }




    public bool AddNegativeCommetForFood(Guid IdForComment, string addingComment)
    {
        var findFood = GetById(IdForComment);

        if (findFood is null)
        {
            return false;
        }

        var index = ListedFood.IndexOf(findFood);
        ListedFood[index].NegativComments.Add(addingComment);
        return true;
    }







    public bool AddPeopleForEating(Guid Id, int people)
    {
        var findFood = GetById(Id);

        if(findFood is null)
        {
            return false;
        }

        var index = ListedFood.IndexOf(findFood);
        ListedFood[index].AmountOfPeopleForEating += people;
        return true;
    }

    


    public Food GetMostNegCommentedFood()
    {
        var collectOfNegComments = new Food();

        foreach(var negativeComments in ListedFood)
        {
            if(negativeComments.NegativComments.Count > collectOfNegComments.NegativComments.Count)
            {
                collectOfNegComments = negativeComments;
            }
        }
        return collectOfNegComments;
    }




    public Food GetMostEatenFood()
    {
        var responce = new Food();

        foreach(var food in ListedFood)
        {
            if(food.AmountOfPeopleForEating > responce.AmountOfPeopleForEating)
            {
                responce = food;
            }
        }
        return responce;
    }



    public void DataSeed()
    {
        var food1 = new Food
        {
            Id = Guid.NewGuid(),
            Name = "Sushi",
            NationOfFood = "Uzbek",
            CommentOfFood = new List<string> { "Fresh", "Delicious", "Healthy" },
            Performance = 4.5,
            AmountOfPeopleForEating = 2,
            NegativComments = new List<string> { "Expensive", "Too raw for some" }
        };

        var food2 = new Food
        {
            Id = Guid.NewGuid(),
            Name = "Tacos",
            NationOfFood = "Turkish",
            CommentOfFood = new List<string> { "Spicy", "Tasty", "Affordable" },
            Performance = 4.0,
            AmountOfPeopleForEating = 4,
            NegativComments = new List<string> { "Can be messy", "Too greasy" }
        };

        var food3 = new Food
        {
            Id = Guid.NewGuid(),
            Name = "Pizza",
            NationOfFood = "Europian",
            CommentOfFood = new List<string> { "Cheesy", "Flavorful", "Comforting" },
            Performance = 4.7,
            AmountOfPeopleForEating = 3,
            NegativComments = new List<string> { "Caloric", "Too much cheese" }
        };

        ListedFood.Add(food2);
        ListedFood.Add(food3);
        ListedFood.Add(food1);

    }





}
