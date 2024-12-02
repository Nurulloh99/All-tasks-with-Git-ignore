using CRUD_Post.Models;
using CRUD_Post.Services;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace CRUD_Post;

public class Program
{
    static void Main(string[] args)
    {

        RunBooksFrontEnd();

    }


    public static void RunBooksFrontEnd()
    {

        while (true)
        {

            var bookServices = new Book_service();

            while (true)
            {

                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Delete book");
                Console.WriteLine("3. Update book");
                Console.WriteLine("4. Get by Id of book");
                Console.WriteLine("5. Get all books");
                Console.WriteLine("6. Get expensive book");
                Console.WriteLine("7. Get most paged book");
                Console.WriteLine("8. Get most read book");
                Console.WriteLine("9. Get books by reader name");
                Console.WriteLine("10. Get books by author name");
                Console.WriteLine("11. Add reader to book");
                Console.WriteLine("12. Add author to book");
                Console.WriteLine();
                Console.Write("Enter your option >> "); 
                var option = int.Parse(Console.ReadLine());


                if (option == 1)
                {
                    var bookResult = new Book();

                    Console.Write("Enter the book's name >> ");
                    bookResult.Name = Console.ReadLine();

                    Console.Write("Enter publication date >> ");
                    bookResult.PublicationDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter description >> ");
                    bookResult.Description = Console.ReadLine();

                    Console.Write("Enter the page number >> ");
                    bookResult.PageNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter price of the book >> ");
                    bookResult.Price = Double.Parse(Console.ReadLine());

                    Console.Write("Enter authors count >> ");
                    var authorCount = int.Parse(Console.ReadLine());
                    for (var i = 0; i < authorCount; i++)
                    {
                        Console.Write("Enter author name >> ");
                        bookResult.AuthorsName.Add(Console.ReadLine());
                    }

                    Console.Write("Enter reader count >> ");
                    var readerCount = int.Parse(Console.ReadLine());
                    for (var i = 0; i < readerCount; i++)
                    {
                        Console.Write("Enter reader name >> ");
                        bookResult.ReadersName.Add(Console.ReadLine());
                    }

                    bookServices.AddBook(bookResult);
                }
                if(option is 2)
                {
                    Console.Write("Enter book's Id >> ");
                    var bookID = Guid.Parse(Console.ReadLine());

                    var result = bookServices.DeleteBook(bookID);
                    
                    if(result is false)
                    {
                        Console.WriteLine("Not deleted");
                    }
                    else
                    {
                        Console.WriteLine("Deleted successfully!");
                    }

                }
                else if(option is 3)
                {
                    var bookResult = new Book();

                    Console.Write("Enter Id of the book >> ");
                    bookResult.Id = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter the book's name >> ");
                    bookResult.Name = Console.ReadLine();

                    Console.Write("Enter publication date >> ");
                    bookResult.PublicationDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter description >> ");
                    bookResult.Description = Console.ReadLine();

                    Console.Write("Enter the page number >> ");
                    bookResult.PageNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter price of the book >> ");
                    bookResult.Price = Double.Parse(Console.ReadLine());

                    Console.Write("Enter authors count >> ");
                    var authorCount = int.Parse(Console.ReadLine());
                    for (var i = 0; i < authorCount; i++)
                    {
                        Console.Write("Enter author name >> ");
                        bookResult.AuthorsName.Add(Console.ReadLine());
                    }

                    Console.Write("Enter reader count >> ");
                    var readerCount = int.Parse(Console.ReadLine());
                    for (var i = 0; i < readerCount; i++)
                    {
                        Console.Write("Enter reader name >> ");
                        bookResult.ReadersName.Add(Console.ReadLine());
                    }

                    var result = bookServices.UpdateBook(bookResult);

                    if(result is false)
                    {
                        Console.WriteLine("Book is not updated");
                    }
                    else
                    {
                        Console.WriteLine("Updated successfully!");
                    }
                }
                else if(option is 4)
                {
                    Console.Write("Enter Id of the book >> ");
                    var bookId = Guid.Parse(Console.ReadLine());

                    var result = bookServices.GetById(bookId);
                    if(result is null)
                    {
                        Console.WriteLine("Error occured");
                    }
                    else
                    {
                        Console.WriteLine("Here you go!!!");
                    }
                }
                else if(option is 5)
                {
                    var books = bookServices.GetAllBooks();

                    foreach(var book in books)
                    {
                        var str = $"Name: {book.Name}\n Publicated date: {book.PublicationDate}\n " +
                            $"Description: {book.Description}\n Page number: {book.PageNumber}\n Rate of the book: {book.Price}" +
                            $"Authors name >> ";
                        foreach(var authorName in book.AuthorsName)
                        {
                            str += authorName + " ";
                        }

                        str += "Reader name >> ";

                        foreach(var readerName in book.ReadersName)
                        {
                            str += readerName + " ";
                        }
                    }

                }
                else if (option is 6)
                {
                    var book = bookServices.GetExpensiveBook();

                    var str = $"Name: {book.Name}\n Publication date: {book.PublicationDate}\n Description: {book.Description}\n " +
                        $"Page number: {book.PageNumber}\n Rate of the book: {book.Price}\n" +
                        $"Author names >> ";
                    
                    foreach(var resOfBook in book.AuthorsName)
                    {
                        str += resOfBook + " ";
                    }

                    str += "Reader names >> ";

                    foreach(var readerName in book.ReadersName)
                    {
                        str += readerName + " ";
                    }
                }
                else if(option is 7)
                {
                    var book = bookServices.GetMostPagedBook();

                    var str = $"Name: {book.Name}\n Publication date: {book.PublicationDate}\n Description: {book.Description}\n Page number: {book.PageNumber}\n " +
                        $"Rate of the book: {book.Price}\n Author names >> ";
                    foreach(var authorName in book.AuthorsName)
                    {
                        str += authorName + " ";
                    }
                    str += "Reader name >> ";
                    foreach(var readerName in book.ReadersName)
                    {
                        str += readerName + " ";
                    }
                }
                else if(option is 8)
                {
                    var book = bookServices.GetMostReadBook();

                    var str = $"Name: {book.Name}\n Publication date: {book.PublicationDate}\n Description: {book.Description}\n Page number: {book.PageNumber}\n " +
                        $"Rate of the book: {book.Price}\n Author names >> ";
                    foreach(var authorName in book.AuthorsName)
                    {
                        str += authorName + " ";
                    }
                    str += "Reader names >> ";
                    foreach(var readerNames in book.ReadersName)
                    {
                        str += readerNames + " ";
                    }
                }
                else if(option is 8)
                {
                    Console.Write("Enter reader name >> ");
                    var books = bookServices.GetBooksByReaderName(Console.ReadLine());

                    foreach (var book in books)
                    {
                        var str = $"Name: {book.Name}\n Publicated date: {book.PublicationDate}\n " +
                            $"Description: {book.Description}\n Page number: {book.PageNumber}\n Rate of the book: {book.Price}" +
                            $"Authors name >> ";
                        foreach (var authorName in book.AuthorsName)
                        {
                            str += authorName + " ";
                        }

                        str += "Reader name >> ";

                        foreach (var readerName in book.ReadersName)
                        {
                            str += readerName + " ";
                        }
                    }
                }
                else if(option is 10)
                {
                    Console.Write("Enter author name >> ");
                    var books = bookServices.GetBooksByAuthorName(Console.ReadLine());

                    foreach (var book in books)
                    {
                        var str = $"Name: {book.Name}\n Publicated date: {book.PublicationDate}\n " +
                            $"Description: {book.Description}\n Page number: {book.PageNumber}\n Rate of the book: {book.Price}" +
                            $"Authors name >> ";
                        foreach (var authorName in book.AuthorsName)
                        {
                            str += authorName + " ";
                        }

                        str += "Reader name >> ";

                        foreach (var readerName in book.ReadersName)
                        {
                            str += readerName + " ";
                        }
                    }
                }
                else if(option is 11)
                {
                    Console.Write("Enter book's ID >> ");
                    var booksId = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter reader name >> ");
                    var readerName = Console.ReadLine();

                    var result = bookServices.AddReaderToBook(booksId, readerName);

                    if(result is false)
                    {
                        Console.WriteLine("Not added or error occured stupid");
                    }
                    else
                    {
                        Console.WriteLine("Added successfully!!!");
                    }
                }
                else if(option is 12)
                {
                    Console.Write("Enter book's ID >> ");
                    var booksId = Guid.Parse(Console.ReadLine());

                    Console.Write("Enter author name >> ");
                    var authorName = Console.ReadLine();

                    var result = bookServices.AddAuthorToBook(booksId, authorName);

                    if (result is false)
                    {
                        Console.WriteLine("Not added or error occured stupid");
                    }
                    else
                    {
                        Console.WriteLine("Added successfully!!!");
                    }
                }


                

                


                

                













            }
        }






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
            Console.Clear();


            if (nationOption == "1")
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
            Console.WriteLine("1. Add Restaurant!                    2. Add Food!");
            Console.WriteLine("3. Get by ID of Restaurant!           4. Get by ID of Food");
            Console.WriteLine("5. Delete Restaurant!                 6. Delete Food");
            Console.WriteLine("7. Update Restaurant!                 8. Update Food");
            Console.WriteLine("9. Get all Foods                      10. Get Food By Nation");
            Console.WriteLine("11. Comments of Food                  12. Negative comments of Food");
            Console.WriteLine("13. Add comments for Food!            14. Add negative comments for food!");
            Console.WriteLine("15. Add Amount of People for eating!  16.Get Most Negative Food");
            Console.WriteLine("17.Get All Restaruants                18.Get Most Eaten Food");

            Console.Write("Choose one of them >> ");
            var option = Console.ReadLine();
            Console.Clear();

            if (option == "1")
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
                    str += "\nNegative Comments: ";
                    foreach(var negCom in result.NegativComments)
                    {
                        str += negCom + " ";
                    }
                    Console.Write($"Result >> {str}");
                }
            }else if(option == "5")
            {
                Console.Write("Enter restaurant ID to delete >> ");
                var resID = Guid.Parse(Console.ReadLine());

                var result = restaurantService.DeleteRestaurant(resID);
                if(result is true)
                {
                    Console.WriteLine("Restaurant has been removed succesfully!!!");
                }
                else
                {
                    Console.WriteLine("ERROR! Not Deleted!");
                }
            }else if(option == "6")
            {
                Console.Write("Enter food ID to delete >> ");
                var fooID = Guid.Parse(Console.ReadLine());

                var result = foodService.DeletedFood(fooID);
                if (result is true)
                {
                    Console.WriteLine("Food has been removed succesfully!!!");
                }
                else
                {
                    Console.WriteLine("ERROR! Not Deleted!");
                }
            }else if(option == "7")
            {
                var restObj = new Restaurant();

                Console.Write("Enter restaurant ID to update >> ");
                var resID = Guid.Parse(Console.ReadLine());

                Console.Write("Enter restaurant name to update >> ");
                restObj.Name = Console.ReadLine();

                Console.Write("Enter restaurant Location to update >> ");
                restObj.Location = Console.ReadLine();

                Console.Write("Enter restaurant Description to update >> ");
                restObj.Description = Console.ReadLine();

                Console.Write("Enter restaurant Opened_Date to update >> ");
                restObj.Opened_Date = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Nation_of_restaurant to update >> ");
                restObj.Nation_of_restaurant = Console.ReadLine();


                var result = restaurantService.UpdatingRestaurant(resID, restObj);
                if(result is true)
                {
                    Console.WriteLine("Restaurant has been updated successfully!!!");
                }
                else
                {
                    Console.WriteLine("ERROR! Not updated");
                }
            }
            else if(option == "8")
            {

                var typeOfFood = new Food();

                Console.Write("Enter Food ID to update >> ");
                var foodID = Guid.Parse(Console.ReadLine());

                Console.Write("Enter Food ID to update >> ");
                typeOfFood.Name = Console.ReadLine();

                Console.Write("Enter NationOfFood to update >> ");
                typeOfFood.NationOfFood = Console.ReadLine();

                Console.Write("Enter Performance to update >> ");
                typeOfFood.Performance = Double.Parse(Console.ReadLine());

                Console.Write("Enter AmountOfPeopleForEating to update >> ");
                typeOfFood.AmountOfPeopleForEating = int.Parse(Console.ReadLine());

                Console.Write("Enter amount of comments >> ");
                var comments = int.Parse(Console.ReadLine());

                for(var i = 0; i < comments; i++)
                {
                    Console.Write("Enter comment >> ");
                    var comMent = Console.ReadLine();

                    typeOfFood.CommentOfFood.Add(comMent);
                }

                Console.Write("Enter amount of negative comments >> ");
                var negComments = int.Parse(Console.ReadLine());

                for(var i = 0; i < negComments; i++)
                {
                    Console.Write("Enter comment >> ");
                    var commeNt = Console.ReadLine();

                    typeOfFood.NegativComments.Add(commeNt);
                }

                var secondResult = foodService.UpdatedFood(foodID, typeOfFood);
                if (secondResult is true)
                {
                    Console.WriteLine("Food has been updted successfully!!!");
                }
                else
                {
                    Console.WriteLine("ERROR!!!");
                }

            }else if(option == "9")
            {
                var collection = foodService.GetAllFood();

                foreach(var food in collection)
                {
                    var str = $"ID: {food.Id}, Name: {food.Name}, Nation: {food.NationOfFood}, Performance: {food.AmountOfPeopleForEating}, " +
                        $"Comments >> ";

                    foreach(var comment in food.CommentOfFood)
                    {
                        str += comment + " ";
                    }

                    str += "\nNegative Comments >> ";

                    foreach(var negComment in food.NegativComments)
                    {
                        str += negComment + " ";
                    }
                    if(str is null)
                    {
                        Console.WriteLine("Error!");
                    }
                    else
                    {
                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                }
            }else if(option == "10")
            {
                var foodByNation = restaurantService.GetAllFoodsByNation(nation);
                if (foodByNation is null)
                {
                    Console.WriteLine("ERROR!!!");
                }
                else
                {
                    foreach(var result in foodByNation)
                    {
                        var str = $"Food ID: {result.Id}\n Food name: {result.Name}\n " +
                        $"Food NationOfFood: {result.NationOfFood}\n Food Performance: " +
                        $"{result.Performance}\n Food AmountOfPeopleForEating: {result.AmountOfPeopleForEating}\n " +
                        $"CommentOfFood: ";

                        foreach (var typeOfFood in result.CommentOfFood)
                        {
                            str += typeOfFood + " ";
                        }
                        str += "\nNegative Comments: ";
                        foreach (var negCom in result.NegativComments)
                        {
                            str += negCom + " ";
                        }
                        Console.Write($"Result >> {str}");
                    }
                }
            }else if(option == "11")
            {
                Console.Write("Enter food's ID >> ");
                var comID = Guid.Parse(Console.ReadLine());

                var result = foodService.GetById(comID);
                if(result is null)
                {
                    Console.WriteLine("Error!");
                }
                else
                {
                    var str = "CommentOfFood: ";

                    foreach (var typeOfFood in result.CommentOfFood)
                    {
                        str += typeOfFood + " ";
                    }
                    Console.Write($"Result >> {str}");
                }

            }else if(option == "12")
            {
                Console.Write("Enter food's ID >> ");
                var comID = Guid.Parse(Console.ReadLine());

                var result = foodService.GetById(comID);
                if (result is null)
                {
                    Console.WriteLine("Error!");
                }
                else
                {
                    var str = "Negative CommentOfFood: ";

                    foreach (var typeOfFood in result.NegativComments)
                    {
                        str += typeOfFood + " ";
                    }
                    Console.Write($"Result >> {str}");
                }
            }else if(option == "13")
            {
                Console.Write("Enter food ID >> ");
                var commentsID = Guid.Parse(Console.ReadLine());
                Console.Write("Enter comment >> ");
                var secondComment = Console.ReadLine();

                var result = foodService.AddCommetForFood(commentsID, secondComment);
                if(result is false)
                {
                    Console.WriteLine("ERROR");
                }
                else
                {
                    Console.WriteLine("Added successfully!!!");
                }

            }else if(option == "14")
            {
                Console.Write("Enter food ID >> ");
                var commentsID = Guid.Parse(Console.ReadLine());
                Console.Write("Enter negative comment >> ");
                var secondComment = Console.ReadLine();

                var result = foodService.AddNegativeCommetForFood(commentsID, secondComment);
                if (result is false)
                {
                    Console.WriteLine("ERROR");
                }
                else
                {
                    Console.WriteLine("Added successfully!!!");
                }
            }else if(option == "15")
            {
                Console.Write("Enter food's ID >> ");
                var foodID = Guid.Parse(Console.ReadLine());

                Console.Write("Enter amount of people >> ");
                var amauntOfPeople = int.Parse(Console.ReadLine());

                var result = foodService.AddPeopleForEating(foodID, amauntOfPeople);

                if(result is false)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    Console.WriteLine("Result >> Added successfully");
                }


            }else if(option == "16")
            {
                var result = foodService.GetMostNegCommentedFood();

                if(result is null)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    var str = String.Empty;
                    str += "\nNegative Comments: ";
                    foreach (var negCom in result.NegativComments)
                    {
                        str += negCom + " ";
                    }
                    Console.Write($"Result >> {str}");
                }

            }else if(option == "17")
            {
                var res = restaurantService.GetAllRestaurants();

                if(res is null)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    foreach(var result in res)
                    {
                        var str = $"Restaurant ID: {result.Id}\n Restaurant name: {result.Name}\n " +
    $"Restaurant location: {result.Location}\n Restaurant description: " +
    $"{result.Description}\n Restaurant Opened_Date: {result.Opened_Date}\n Restaurant nation_of_restaurant: {result.Nation_of_restaurant}";

                        Console.WriteLine(str);
                    }
                }

            }else if(option == "18")
            {
                var result = foodService.GetMostEatenFood();

                var str = $"Food ID: {result.Id}\n Food name: {result.Name}\n " +
                        $"Food NationOfFood: {result.NationOfFood}\n Food Performance: " +
                        $"{result.Performance}\n Food AmountOfPeopleForEating: {result.AmountOfPeopleForEating}\n " +
                        $"CommentOfFood: ";

                foreach (var typeOfFood in result.CommentOfFood)
                {
                    str += typeOfFood + " ";
                }
                str += "\nNegative Comments: ";
                foreach (var negCom in result.NegativComments)
                {
                    str += negCom + " ";
                }
                Console.Write($"Result >> {str}");

            }
            Console.ReadKey();
            Console.Clear();
        }
        
    }














































    


}
