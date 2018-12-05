using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Pools;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class PoolsController : Controller
    {
        private IPoolService poolService;

        public PoolsController(IPoolService poolService)
        {
            this.poolService = poolService;
        }

        public IActionResult All()
        {
            var pools = this.poolService.GetPools();
            
            if (pools == null)
            {
                return this.Redirect("/");
            }

            var model = pools.Select(x => new AllPoolViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Users = this.poolService.GetPoolsParticipants(x.Id),
                Answers = this.poolService.GetPoolsAnswers(x.Id),
                
            });

            return this.View(model);
        }

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