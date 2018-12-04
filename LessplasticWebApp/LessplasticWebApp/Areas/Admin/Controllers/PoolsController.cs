using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Pools;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PoolsController : Controller
    {
        private IPoolService poolService;

        public PoolsController(IPoolService poolService)
        {
            this.poolService = poolService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(PoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.poolService.CreateEvent(model);

            return this.Redirect("/Pools/Details?id=" + id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var pool = this.poolService.GetPool(id);

            if (pool == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeletePoolViewModel
            {
                Id = pool.Id,
                Title = pool.Title,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeletePoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var pool = this.poolService.GetPool(model.Id);

            if (pool == null)
            {
                return this.Redirect("/");
            }

            this.poolService.EditEvent(pool, model);

            return this.Redirect("/Pools/All");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var pool = this.poolService.GetPool(id);
            var poolAnswers = this.poolService.GetPoolsAnswers(id);

            if (pool == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeletePoolViewModel
            {
                Id = pool.Id,
                Title = pool.Title,
                Answers = poolAnswers,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var pool = this.poolService.GetPool(id);

            if (pool == null)
            {
                return this.Redirect("/");
            }

            this.poolService.DeleteEvent(pool);

            return this.Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddParticipant(int id)
        {
            var pool = this.poolService.GetPool(id);

            if (pool == null)
            {
                return this.Redirect("/");
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var user = this.User.Identity.Name;

            this.poolService.AddParticipant(pool, user);

            return this.Redirect("/Pools/All");
        }
    }
}