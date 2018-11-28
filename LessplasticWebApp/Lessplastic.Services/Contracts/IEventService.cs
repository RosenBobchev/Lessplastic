using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Services.Contracts
{
    public interface IEventService
    {
        Event GetEvent(int id);

        Event[] GetEvents();

        int CreateEvent(EventViewModel model);

        void EditEvent(Event myEvent, UpdateDeleteEventViewModel model);

        void DeleteEvent(Event myEvent);

        EventTowns[] GetEventTowns(int id);

        UserEvents[] GetEventParticipants(int id);

        bool AddParticipant(Event myEvent, string username);
    }
}
