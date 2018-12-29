using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Educations;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class EducationServiceTests
    {
        [Fact]
        public void CreateEducationShouldCreateEducation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_CreatingEducations").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            var model = new EducationViewModel
            {
                Title = "Title",
                AdditionalContent = "Something",
                AdditionalContentImage = "Something",
                Content = "Something",
                DownloadLink = "Something",
                ImageUrl = "Something",
            };

            var education = service.CreateEducation(model);

            Assert.Equal(1, education);
        }

        [Fact]
        public void IncrementViewsShouldIncreaseCounterOnViews()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            dbContext.Educations.Add(new Education());
            dbContext.SaveChanges();

            var education = dbContext.Educations.First();

            service.IncrementViews(education);
            service.IncrementViews(education);

            Assert.Equal(2, education.Views);
        }

        [Fact]
        public void DeleteEducationShouldDeleteAnEducationFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.SaveChanges();

            var education = dbContext.Educations.First();

            service.DeleteEducation(education);

            Assert.Equal(2, dbContext.Educations.Count());
        }

        [Fact]
        public void EditEducationShoudEditOneOrMorePropertiesInEducation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            var model = new UpdateDeleteEducationViewModel
            {
                Title = "Edited"
            };

            var education = new Education
            {
                Title = "New"
            };

            dbContext.Educations.Add(education);
            dbContext.SaveChanges();

            var educationToEdit = dbContext.Educations.First();

            service.EditEducation(educationToEdit, model);

            Assert.Equal("Edited", educationToEdit.Title);
        }

        [Fact]
        public void GetEducationShouldReturnAnEducationById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_CreatingEducations").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            var education = new Education
            {
                Title = "Test"
            };

            dbContext.Educations.Add(education);
            dbContext.SaveChanges();

            var returnedEducation = service.GetEducation(1);

            Assert.Equal(education.Title, returnedEducation.Title);
        }

        [Fact]
        public void GetEducationsShouldReturnAllEducations()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Videos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EducationService(dbContext);

            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.SaveChanges();

            var educations = service.GetEducations();

            Assert.Equal(5, educations.Length);
        }
    }
}
