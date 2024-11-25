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
}
