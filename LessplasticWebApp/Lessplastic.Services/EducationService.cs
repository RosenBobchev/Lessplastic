using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Educations;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using System;
using System.Linq;

namespace Lessplastic.Services
{
    public class EducationService : IEducationService
    {
        private ApplicationDbContext context;

        public EducationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int CreateEducation(EducationViewModel model)
        {
            var education = new Education
            {
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl,
                AdditionalContent = model.AdditionalContent,
                AdditionalContentImage = model.AdditionalContentImage,
                DownloadLink = model.DownloadLink
            };

            this.context.Educations.Add(education);
            this.context.SaveChanges();

            var id = education.Id;

            return id;
        }

        public void DeleteEducation(Education education)
        {
            this.context.Remove(education);
            this.context.SaveChanges();
        }

        public void EditEducation(Education education, UpdateDeleteEducationViewModel model)
        {
            education.Title = model.Title;
            education.Content = model.Content;
            education.ImageUrl = model.ImageUrl;
            education.AdditionalContent = model.AdditionalContent;
            education.AdditionalContentImage = model.AdditionalContentImage;

            this.context.SaveChanges();
        }

        public Education GetEducation(int id)
        {
            var education = this.context.Educations.FirstOrDefault(x => x.Id == id);

            return education;
        }

        public Education[] GetEducations()
        {
            var educations = this.context.Educations.ToArray();

            return educations;
        }
    }
}
