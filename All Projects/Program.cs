using CRUD_Post.Models;
using CRUD_Post.Services;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CRUD_Post
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunFrontEnd();
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
    }
}
