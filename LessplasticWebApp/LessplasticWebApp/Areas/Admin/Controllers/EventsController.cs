using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Events;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.eventService.CreateEvent(model);

            return this.Redirect("/Events/Details?id=" + id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var myEvent = this.eventService.GetEvent(id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteEventViewModel
            {
                Id = myEvent.Id,
                Name = myEvent.Name,
                Description = myEvent.Description,
                EventDate = myEvent.EventDate,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeleteEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var myEvent = this.eventService.GetEvent(model.Id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            this.eventService.EditEvent(myEvent, model);

            return this.Redirect("/Events/Details?id=" + model.Id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var myEvent = this.eventService.GetEvent(id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteEventViewModel
            {
                Id = myEvent.Id,
                Name = myEvent.Name,
                Description = myEvent.Description,
                EventDate = myEvent.EventDate,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var myEvent = this.eventService.GetEvent(id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            this.eventService.DeleteEvent(myEvent);

            return this.Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddParticipant(int id)
        {
            var myEvent = this.eventService.GetEvent(id);

            if (myEvent == null)
            {
                return this.Redirect("/");
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var user = this.User.Identity.Name;

            this.eventService.AddParticipant(myEvent, user);

            return this.Redirect("/Events/Details?id=" + id);
        }
    }
}