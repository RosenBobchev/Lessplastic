using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Polls;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class PollServiceTests
    {
        [Fact]
        public void AddParticipantShouldAddParticipantToPoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            dbContext.Polls.Add(new Poll());
            var user = new LessplasticUser
            {
                UserName = "test"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var poll = dbContext.Polls.First();

            service.AddParticipant(poll, "test");

            Assert.Equal(1, dbContext.PollsUsers.Count());
        }

        [Fact]
        public void CreatePollShouldCreatePoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            var model = new PollViewModel
            {
                Title = "something",
                Answers = "Da, Ne, Moje"
            };

            service.CreatePoll(model);

            Assert.Equal(1, dbContext.Polls.Count());
        }

        [Fact]
        public void DeletePollShouldDeletePollFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.SaveChanges();

            var poll = dbContext.Polls.First();

            service.DeletePoll(poll);

            Assert.Equal(2, dbContext.Polls.Count());
        }

        [Fact]
        public void EditPollShoudEditTitleInPoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            var model = new UpdateDeletePollViewModel
            {
                Title = "Edited"
            };

            var poll = new Poll
            {
                Title = "New"
            };

            dbContext.Polls.Add(poll);
            dbContext.SaveChanges();

            var pollToEdit = dbContext.Polls.First();

            service.EditPoll(pollToEdit, model);

            Assert.Equal("Edited", pollToEdit.Title);
        }

        [Fact]
        public void GetPollShouldReturnPollById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            var poll = new Poll
            {
                Title = "Test"
            };

            dbContext.Polls.Add(poll);
            dbContext.SaveChanges();

            var returnedPoll = service.GetPoll(1);

            Assert.Equal(poll.Title, returnedPoll.Title);
        }

        [Fact]
        public void GetPollsShouldReturnAllPollsInDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);
            
            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.Polls.Add(new Poll());
            dbContext.SaveChanges();

            var returnedPolls = service.GetPolls();
            
            Assert.Equal(5, returnedPolls.Length);
        }

        [Fact]
        public void IncrementVotersShouldIncrementOnTheGivenAnswerItsVotersProperty()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            var model = new PollViewModel
            {
                Title = "something",
                Answers = "Da, Ne, Moje"
            };

            service.CreatePoll(model);

            service.IncrementVoters(1, 1);

            var firstAnswer = dbContext.Answers.First();

            Assert.Equal("Da", firstAnswer.Name);
            Assert.Equal(1, firstAnswer.Voters);
        }

        [Fact]
        public void GetPollsParticipantsShouldReturnAllParticipantsFromPoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            dbContext.Polls.Add(new Poll());
            var user = new LessplasticUser
            {
                UserName = "test"
            };
            var secondUser = new LessplasticUser
            {
                UserName = "test2"
            };
            dbContext.Users.Add(user);
            dbContext.Users.Add(secondUser);
            dbContext.SaveChanges();

            var poll = dbContext.Polls.First();

            service.AddParticipant(poll, "test");
            service.AddParticipant(poll, "test2");

            var participants = service.GetPollsParticipants(poll.Id);

            Assert.Equal(2, participants.Length);
        }

        [Fact]
        public void GetPollsAnswersShouldReturnAllAnswersFromPoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new PollsService(dbContext);

            var model = new PollViewModel
            {
                Title = "something",
                Answers = "Da, Ne, Moje"
            };

            service.CreatePoll(model);

            var answers = service.GetPollsAnswers(1);

            Assert.Equal(3, answers.Length);
        }
    }
}
