using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Events;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class EventsController : Controller
    {
        private IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Details(int id)
        {
            var myEventTowns = this.eventService.GetEventTowns(id);

            var myEventParticipants = this.eventService.GetEventParticipants(id);

            var myEvent = this.eventService.GetEvent(id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            var model = new DetailsEventViewModel
            {
                Id = myEvent.Id,
                Name = myEvent.Name,
                Description = myEvent.Description,
                EventDate = myEvent.EventDate,
                Participants = myEventParticipants,
                Towns = myEventTowns,
            };

            return this.View(model);
        }

        public IActionResult All()
        {
            var events = this.eventService.GetEvents();

            var model = events.Select(x => new AllEventsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedOn = x.CreatedOn,
            }).OrderByDescending(x => x.CreatedOn).ToList();

            return this.View(model);
        }
    }
}