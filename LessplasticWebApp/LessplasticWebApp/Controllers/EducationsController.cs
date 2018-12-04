using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Educations;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class EducationsController : Controller
    {
        private IEducationService educationService;

        public EducationsController(IEducationService educationService)
        {
            this.educationService = educationService;
        }
        
        public IActionResult Details(int id)
        {
            var education = this.educationService.GetEducation(id);

            if (education == null)
            {
                return this.Redirect("/");
            }

            this.educationService.IncrementViews(education);

            var model = new DetailsEducationViewModel
            {
                Id = education.Id,
                Title = education.Title,
                Content = education.Content,
                ImageUrl = education.ImageUrl,
                AdditionalContent = education.AdditionalContent,
                AdditionalContentImage = education.AdditionalContentImage,
                CreatedOn = education.CreatedOn,
                Views = education.Views,
            };

            return this.View(model);
        }
        
        public IActionResult All()
        {
            var educations = this.educationService.GetEducations();

            var model = educations.Select(x => new AllEducationsViewModel
            {
                Id = x.Id,
                Content = x.Content,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                AdditionalContent = x.AdditionalContent,
                AdditionalContentImage = x.AdditionalContentImage,
                DownloadLink = x.DownloadLink,
                CreatedOn = x.CreatedOn,
            })
            .OrderByDescending(x => x.CreatedOn).ToList();

            return this.View(model);
        }
    }
}