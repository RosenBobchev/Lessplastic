using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Polls;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PollsController : Controller
    {
        private IPollService pollService;

        public PollsController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(PollViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.pollService.CreatePoll(model);

            return this.Redirect("/Polls/All");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var poll = this.pollService.GetPoll(id);

            if (poll == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeletePollViewModel
            {
                Id = poll.Id,
                Title = poll.Title,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeletePollViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var poll = this.pollService.GetPoll(model.Id);

            if (poll == null)
            {
                return this.Redirect("/");
            }

            this.pollService.EditPoll(poll, model);

            return this.Redirect("/Polls/All");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var poll = this.pollService.GetPoll(id);
            var pollAnswers = this.pollService.GetPollsAnswers(id);

            if (poll == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeletePollViewModel
            {
                Id = poll.Id,
                Title = poll.Title,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var poll = this.pollService.GetPoll(id);

            if (poll == null)
            {
                return this.Redirect("/");
            }

            this.pollService.DeletePoll(poll);

            return this.Redirect("/");
        }
    }
}