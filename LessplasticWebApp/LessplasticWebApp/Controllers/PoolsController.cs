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
                Users = x.Users,
                Answers = x.Answers
            });

            return this.View(model);
        }
    }
}