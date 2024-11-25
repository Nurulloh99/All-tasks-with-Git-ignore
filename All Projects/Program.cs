using CRUD_Post.Models;
using CRUD_Post.Services;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CRUD_Post;

public class Program
{
    static void Main(string[] args)
    {
        SecondFrontEnd();
    }

    public static void RunFrontEnd()
    {

        var eventServices = new EventService();

        while (true)
        {
            Console.WriteLine("1. Adding event");
            Console.WriteLine("2. Get by ID");
            Console.WriteLine("3. Delete event");
            Console.WriteLine("4. Update event");
            Console.WriteLine("5. Get all events");
            Console.WriteLine("6. Get events by location");
            Console.WriteLine("7. Get popular events");
            Console.WriteLine("8. Get more tagged event\n");
            Console.Write("Enter your option >> ");
            var option = int.Parse(Console.ReadLine());

            Console.Clear();

            if(option == 1)
            {

                var eventt = new Event();

                Console.Write("Enter Title >> ");
                eventt.Name = Console.ReadLine();
                Console.Write("Enter Location >> ");
                eventt.Location = Console.ReadLine();
                Console.Write("Enter Date time >> ");
                eventt.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Description >> ");
                eventt.Description = Console.ReadLine();


                eventt.AttendenceMembers = new List<string>();

                Console.Write("Enter Count of members >> ");
                var count = int.Parse(Console.ReadLine());

                for(var i = 0; i < count; i++)
                {
                    Console.Write("Enter Attendence Members >> ");
                    var names = Console.ReadLine();
                    eventt.AttendenceMembers.Add(names);
                }

                Console.Write("Enter taggs count >> ");
                var taggsCount = int.Parse(Console.ReadLine());

                for(var i = 0; i < taggsCount; i++)
                {
                    Console.Write("Enter tagg >> ");
                    var taggg = Console.ReadLine();
                    eventt.Tags.Add(taggg);
                }
                eventServices.AddedEvent(eventt);
            }

            else if (option == 2)
            {

                Console.Write("Enter ID >> ");
                var eventID = Guid.Parse(Console.ReadLine());
                var evenIDRes = eventServices.GetByID(eventID);

                var inform = $" ID: {evenIDRes.Id}\n Title: {evenIDRes.Name}\n Location: {evenIDRes.Location}\n Date time: {evenIDRes.Date}\n " +
                    $"Description: {evenIDRes.Description}\n Names of members: ";
                foreach(var name in evenIDRes.AttendenceMembers)
                {
                    inform += name + " ";
                }
                inform += " \n Tags: ";
                foreach(var tag in evenIDRes.Tags)
                {
                    inform += tag + " ";
                }
            }
            else if(option == 3)
            {
                Console.Write("Enter event ID to remove >> ");
                var eventID = Guid.Parse(Console.ReadLine());

                var result = eventServices.DeletedEvent(eventID);
                if(result is true)
                {
                    Console.WriteLine("Event has been deleted successfully!!!");
                }
                else
                {
                    Console.WriteLine("Error, Not Deleted!");
                }

            }else if(option == 4)
            {
                var updatingEvent = new Event();

                Console.Write("Enter event ID which you want to update >> ");
                updatingEvent.Id = Guid.Parse(Console.ReadLine());
                Console.Write("Enter Title >> ");
                updatingEvent.Name = Console.ReadLine();
                Console.Write("Enter Location >> ");
                updatingEvent.Location = Console.ReadLine();
                Console.Write("Enter Date time >> ");
                updatingEvent.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Description >> ");
                updatingEvent.Description = Console.ReadLine();


                updatingEvent.AttendenceMembers = new List<string>();

                Console.Write("Enter Count of members >> ");
                var count = int.Parse(Console.ReadLine());

                for (var i = 0; i < count; i++)
                {
                    Console.Write("Enter Attendence Members >> ");
                    var names = Console.ReadLine();
                    updatingEvent.AttendenceMembers.Add(names);
                }

                Console.Write("Enter taggs count >> ");
                var taggsCount = int.Parse(Console.ReadLine());

                for (var i = 0; i < taggsCount; i++)
                {
                    Console.Write("Enter tagg >> ");
                    var taggg = Console.ReadLine();
                    updatingEvent.Tags.Add(taggg);
                }

                var result = eventServices.UpdatedEvent(updatingEvent.Id, updatingEvent);

                if(result is true)
                {
                    Console.WriteLine("Event has been completed successfully!!!");
                }
                else
                {
                    Console.WriteLine("Error, not updated!!!");
                }
            }else if(option == 5)
            {
                var allEvents = eventServices.GetAllEvents();

                foreach(var evvent in allEvents)
                {
                    var evenIDRes = evvent;

                    var inform = $" ID: {evenIDRes.Id}\n Title: {evenIDRes.Name}\n Location: {evenIDRes.Location}\n Date time: {evenIDRes.Date}\n " +
                    $"Description: {evenIDRes.Description}\n Names of members: ";
                    foreach (var name in evenIDRes.AttendenceMembers)
                    {
                        inform += name + " ";
                    }
                    inform += " \n Tags: ";
                    foreach (var tag in evenIDRes.Tags)
                    {
                        inform += tag + " ";
                    }
                    Console.WriteLine(inform);

                    Console.WriteLine( "\n\n");
                }
            }else if(option == 6)
            {
                Console.Write("Enter location >> ");
                var eventLocation = Console.ReadLine();
                var allEventsList = eventServices.GetEventsByLocation(eventLocation);

                foreach (var evvent in allEventsList)
                {
                    var evenIDRes = evvent;

                    var inform = $" ID: {evenIDRes.Id}\n Title: {evenIDRes.Name}\n Location: {evenIDRes.Location}\n Date time: {evenIDRes.Date}\n " +
                    $"Description: {evenIDRes.Description}\n Names of members: ";
                    foreach (var name in evenIDRes.AttendenceMembers)
                    {
                        inform += name + " ";
                    }
                    inform += " \n Tags: ";
                    foreach (var tag in evenIDRes.Tags)
                    {
                        inform += tag + " ";
                    }
                    Console.WriteLine(inform);
                }
            }else if(option == 7)
            {
                var evenIDRes = eventServices.GetPopularEvent();

                if (evenIDRes is null)
                {
                    Console.WriteLine("Error, not found!");
                }
                else
                {

                    var inform = $" ID: {evenIDRes.Id}\n Title: {evenIDRes.Name}\n Location: {evenIDRes.Location}\n Date time: {evenIDRes.Date}\n " +
                        $"Description: {evenIDRes.Description}\n Names of members: ";
                    foreach (var name in evenIDRes.AttendenceMembers)
                    {
                        inform += name + " ";
                    }
                    inform += " \n Tags: ";
                    foreach (var tag in evenIDRes.Tags)
                    {
                        inform += tag + " ";
                    }
                    Console.WriteLine(inform);
                }
            }
            else if (option == 8)
            {
                var evenIDRes = eventServices.GetMaxTaggedEvent();

                if (evenIDRes is null)
                {
                    Console.WriteLine("Error, not found!");
                }
                else
                {
                    var inform = $" ID: {evenIDRes.Id}\n Title: {evenIDRes.Name}\n Location: {evenIDRes.Location}\n Date time: {evenIDRes.Date}\n " +
                        $"Description: {evenIDRes.Description}\n Names of members: ";
                    foreach (var name in evenIDRes.AttendenceMembers)
                    {
                        inform += name + " ";
                    }
                    inform += " \n Tags: ";
                    foreach (var tag in evenIDRes.Tags)
                    {
                        inform += tag + " ";
                    }
                    Console.WriteLine(inform);
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }




    public static void SecondFrontEnd()
    {
        var restaurantService = new Restaurant_service();
        var foodService = new Food_service();


        while (true)
        {
            Console.WriteLine("CHOOSE NATION OF FOODS\n");
            Console.WriteLine("1. Uzbek Foods");
            Console.WriteLine("2. Turkish Foods");
            Console.WriteLine("3. Europian Foods\n");
            Console.Write("Choose one of them >> ");
            var nationOption = Console.ReadLine();
            var nation = String.Empty;

            if(nationOption == "1")
            {
                nation = "Uzbek";
            }
            else if(nationOption == "2")
            {
                nation = "Turkish";
            }
            else if(nationOption == "3")
            {
                nation = "Europian";
            }

            Console.Write("\tPLAN\n");
            Console.WriteLine("1. Add Restaurant!\t 2. Add Food!");
            Console.WriteLine("3. Get by ID of Restaurant!\t 4. Get by ID of Food");
            Console.WriteLine("5. Delete Restaurant!\t 6. Delete Food");
            Console.WriteLine("7. Update Restaurant!\t 8. Update Food");
            Console.WriteLine("9. Get all Foods\t 10. Get Food By Nation");
            Console.WriteLine("11. Comments of Food\t 12. Negative comments of Food");
            Console.WriteLine("13. Add comments for Food!\t 14. Add negative comments for food!");
            Console.WriteLine("15. Add Amount of People for eating!\n");
            Console.Write("Choose one of them >> ");
            var option = Console.ReadLine();

            if(option == "1")
            {

                var newRestaurant = new Restaurant();
                Console.Write("Name of new restaurant >> ");
                newRestaurant.Name = Console.ReadLine();
                Console.Write("Location of new restaurant >> ");
                newRestaurant.Location = Console.ReadLine();
                Console.Write("Description of new restaurant >> ");
                newRestaurant.Description = Console.ReadLine();
                Console.Write("Nation of new restaurant >> ");
                newRestaurant.Nation_of_restaurant = Console.ReadLine();

                restaurantService.AddRest(newRestaurant);
                Console.WriteLine("New Reastaurant has been added successfully!");
            }
            else if(option == "2")
            {
                var newFoods = new Food();
                Console.Write("Name of food >> ");
                newFoods.Name = Console.ReadLine();

                Console.Write("NationOfFood of food >> ");
                newFoods.NationOfFood = Console.ReadLine();

                Console.Write("Performance of food >> ");
                newFoods.Performance = Double.Parse(Console.ReadLine());

                Console.Write("AmountOfPeopleForEating of food >> ");
                newFoods.AmountOfPeopleForEating = int.Parse(Console.ReadLine());



                Console.Write("Count of comments >> ");
                var count = int.Parse(Console.ReadLine());

                for(var i = 0; i < count; i++)
                {
                    Console.Write("Comment of food >> ");
                    var commment = Console.ReadLine();
                    newFoods.CommentOfFood.Add(commment);
                }



                Console.Write("Count of NegativeComments >> ");
                var counnt = int.Parse(Console.ReadLine());

                for(var i = 0; i < counnt; i++)
                {
                    Console.Write("NegativComments of food >> ");
                    var negComment = Console.ReadLine();
                    newFoods.NegativComments.Add(negComment);
                }

                foodService.AddFood(newFoods);

            }
            else if(option == "3")
            {


                Console.Write("Enter Restaurant ID >> ");
                var restID = Guid.Parse(Console.ReadLine());
                var result = restaurantService.GetById(restID);
                


                if(restaurantService is null)
                {
                    Console.WriteLine("ERROR! Nothing inside of service");
                }
                else
                {
                    var str = $"Restaurant ID: {result.Id}\n Restaurant name: {result.Name}\n " +
                        $"Restaurant location: {result.Location}\n Restaurant description: " +
                        $"{result.Description}\n Restaurant Opened_Date: {result.Opened_Date}\n Restaurant nation_of_restaurant: {result.Nation_of_restaurant}";

                    Console.Write($"Result >> {str}");
                }

            }else if(option == "4")
            {
                Console.Write("Enter ID of Food >> ");
                var IdOfFood = Guid.Parse(Console.ReadLine());
                var result = foodService.GetById(IdOfFood);
                if(result is null)
                {
                    Console.WriteLine("ERROR!");
                }
                else
                {
                    var str = $"Food ID: {result.Id}\n Food name: {result.Name}\n " +
                        $"Food NationOfFood: {result.NationOfFood}\n Food Performance: " +
                        $"{result.Performance}\n Food AmountOfPeopleForEating: {result.AmountOfPeopleForEating}\n " +
                        $"CommentOfFood: ";

                    foreach(var typeOfFood in result.CommentOfFood)
                    {
                        str += typeOfFood + " ";
                    }

                    Console.Write($"Result >> {str}");
                }
            }
        }
    }
}
//public Guid Id { get; set; }
//public string Name { get; set; }
//public string Location { get; set; }
//public string Description { get; set; }
//public DateTime Opened_Date { get; set; } = DateTime.Now;
//public string Nation_of_restaurant { get; set; }


//public Guid Id { get; set; }
//public string Name { get; set; }
//public string NationOfFood { get; set; }
//public List<string> CommentOfFood { get; set; } = new List<string>();
//public double Performance { get; set; }
//public int AmountOfPeopleForEating { get; set; }
//public List<string> NegativComments { get; set; } = new List<string>();

