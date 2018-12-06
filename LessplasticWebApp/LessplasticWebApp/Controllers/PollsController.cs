using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Polls;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class PollsController : Controller
    {
        private IPollService pollService;

        public PollsController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        public IActionResult All()
        {
            var poll = this.pollService.GetPolls();

            if (poll == null)
            {
                return this.Redirect("/");
            }

            var model = poll.Select(x => new AllPollViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreatedOn = x.CreatedOn,
                Users = this.pollService.GetPollsParticipants(x.Id),
                Answers = this.pollService.GetPollsAnswers(x.Id),

            }).OrderByDescending(x => x.CreatedOn).ToList();

            return this.View(model);
        }

        public IActionResult AddParticipant(int id, int idAnswer)
        {
            var poll = this.pollService.GetPoll(id);

            if (poll == null)
            {
                return this.Redirect("/");
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var user = this.User.Identity.Name;

            this.pollService.AddParticipant(poll, user);

            this.pollService.IncrementVoters(id, idAnswer);

            return this.Redirect("/Polls/All");
        }
    }
}