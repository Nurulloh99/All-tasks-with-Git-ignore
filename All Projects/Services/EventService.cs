using CRUD_Post.Models;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_Post.Services;

public class EventService
{
    private List<Event> ListedEvents;

    public EventService()
    {
        ListedEvents = new List<Event>();
        DataSeed();
    }


    public Event AddedEvent(Event addingEvent)
    {
        addingEvent.Id = Guid.NewGuid();
        ListedEvents.Add(addingEvent);
        return addingEvent;
    }


    public Event GetByID(Guid eventID)
    {
        foreach (var check in ListedEvents)
        {
            if (check.Id == eventID)
            {
                return check;
            }
        }
        return null;
    }


    public bool DeletedEvent(Guid eventID)
    {
        var removingEvent = GetByID(eventID);

        if (removingEvent is null)
        {
            return false;
        }

        ListedEvents.Remove(removingEvent);
        return true;
    }


    public bool UpdatedEvent(Guid eventId, Event newEvent)
    {
        var checkEvent = GetByID(eventId);

        if (checkEvent is null)
        {
            return false;
        }

        ListedEvents[ListedEvents.IndexOf(checkEvent)] = newEvent;
        return true;
    }


    public List<Event> GetAllEvents()
    {
        return ListedEvents;
    }



    // ==================================================================================



    public List<Event> GetEventsByLocation(string location)
    {
        var collectEvents = new List<Event>();

        foreach (var eveent in ListedEvents)
        {
            if (eveent.Location == location)
            {
                collectEvents.Add(eveent);
            }
        }
        return collectEvents;
    }



    public Event GetPopularEvent()
    {
        var maxAmount = 0;
        var responceEvent = new Event();

        foreach(var eveent in ListedEvents)
        {
            if(eveent.AttendenceMembers.Count > maxAmount)
            {
                maxAmount = eveent.AttendenceMembers.Count;
                responceEvent = eveent;
            }
        }
        return responceEvent;
    }



    public Event GetMaxTaggedEvent()
    {
        var maxAmount = 0;
        var responceEvent = new Event();

        foreach (var eveent in ListedEvents)
        {
            if (eveent.Tags.Count > maxAmount)
            {
                maxAmount = eveent.Tags.Count;
                responceEvent = eveent;
            }
        }
        return responceEvent;
    }


    public void DataSeed()
    {

        var firstMember = new List<string>();
        firstMember.Add("Nurulloh,");
        firstMember.Add("BekMurod,");
        firstMember.Add("Ilhom,");
        firstMember.Add("Boymurod,");
        firstMember.Add("Dilnoza,");
        firstMember.Add("Shahlo,");
        firstMember.Add("Bunyod.");

        var firstTagList = new List<string>();
        firstTagList.Add("Caraokeda qatnashdik,");
        firstTagList.Add("Hotel tour qildik,");
        firstTagList.Add("Tadbir organizovat qildik.");


        var firstEvent = new Event()
        {
            Id = Guid.NewGuid(),
            Name = "Birthday",
            Location = "Nest One",
            Date = DateTime.Now,
            Description = "Yaxshi bo'ldi tugilgan kun",
            AttendenceMembers = firstMember,
            Tags = firstTagList,
        };


        var secondMember = new List<string>();
        secondMember.Add("Nurulloh,");
        secondMember.Add("BekMurod,");
        secondMember.Add("Ilhom,");
        secondMember.Add("Boymurod,");
        secondMember.Add("Dilnoza,");
        secondMember.Add("Shahlo,");
        secondMember.Add("Bunyod.");

        var secondTagList = new List<string>();
        secondTagList.Add("Caraokeda qatnashdik,");
        secondTagList.Add("Hotel tour qildik,");
        secondTagList.Add("Tadbir organizovat qildik.");


        var secondEvent = new Event()
        {
            Id = Guid.NewGuid(),
            Name = "Birthday",
            Location = "Nest One",
            Date = DateTime.Now,
            Description = "Yaxshi bo'ldi tugilgan kun",
            AttendenceMembers = secondMember,
            Tags = secondTagList,
        };

        ListedEvents.Add(firstEvent);
        ListedEvents.Add(secondEvent);
    }
}