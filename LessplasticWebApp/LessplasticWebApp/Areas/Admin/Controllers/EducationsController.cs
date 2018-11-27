using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Educations;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationsController : Controller
    {
        private IEducationService educationService;

        public EducationsController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(EducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.educationService.CreateEducation(model);

            return this.Redirect("/Admin/Educations/Details?id=" + id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var education = this.educationService.GetEducation(id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            var model = new DetailsEducationViewModel
            {
                Id = education.Id,
                Title = education.Title,
                Content = education.Content,
                ImageUrl = education.ImageUrl,
                AdditionalContent = education.AdditionalContent,
                AdditionalContentImage = education.AdditionalContentImage,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var education = this.educationService.GetEducation(id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteEducationViewModel
            {
                Id = education.Id,
                Title = education.Title,
                Content = education.Content,
                ImageUrl = education.ImageUrl,
                AdditionalContent = education.AdditionalContent,
                AdditionalContentImage = education.AdditionalContentImage,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeleteEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var education = this.educationService.GetEducation(model.Id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            this.educationService.EditEducation(education, model);

            return this.Redirect("/Admin/Educations/Details?id=" + model.Id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var education = this.educationService.GetEducation(id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteEducationViewModel
            {
                Id = education.Id,
                Title = education.Title,
                Content = education.Content,
                ImageUrl = education.ImageUrl,
                AdditionalContent = education.AdditionalContent,
                AdditionalContentImage = education.AdditionalContentImage,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var education = this.educationService.GetEducation(id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            this.educationService.DeleteEducation(education);

            return this.Redirect("/");
        }
    }
}