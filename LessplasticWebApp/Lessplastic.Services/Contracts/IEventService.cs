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

        void CreateEvent(EventViewModel model);

        void EditEvent(Event myEvent, UpdateDeleteEventViewModel model);

        void DeleteEvent(Event myEvent);

        void IncrementParticipants(Event myEvent);
    }
}
