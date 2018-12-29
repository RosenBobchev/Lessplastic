using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Events;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class EventServiceTests
    {
        [Fact]
        public void CreateEventShouldCreateEvent()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Event").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            var model = new EventViewModel
            {
                Name = "test",
                Description = "test",
                EventDate = DateTime.Now,
                Towns = "Burgas, Varna, Sozopol"
            };

            var eventId = service.CreateEvent(model);

            Assert.Equal(2, eventId);
        }

        [Fact]
        public void DeleteEventShouldDeleteEventFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.SaveChanges();

            var testEvent = dbContext.Events.First();

            service.DeleteEvent(testEvent);

            Assert.Equal(2, dbContext.Events.Count());
        }

        [Fact]
        public void EditPollShoudEditTitleInPoll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            var model = new UpdateDeleteEventViewModel
            {
                Name = "Edited",
            };

            var testEvent = new Event
            {
                Name = "New"
            };

            dbContext.Events.Add(testEvent);
            dbContext.SaveChanges();

            var eventToEdit = dbContext.Events.First();

            service.EditEvent(eventToEdit, model);

            Assert.Equal("Edited", eventToEdit.Name);
        }

        [Fact]
        public void GetEventShouldReturnEventById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            var testEvent = new Event
            {
                Name = "Test"
            };

            dbContext.Events.Add(testEvent);
            dbContext.SaveChanges();

            var returnedEvent = service.GetEvent(1);

            Assert.Equal(testEvent.Name, returnedEvent.Name);
        }

        [Fact]
        public void GetEventsShouldReturnAllEventsInDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.Events.Add(new Event());
            dbContext.SaveChanges();

            var returnedEvents = service.GetEvents();

            Assert.Equal(5, returnedEvents.Length);
        }

        [Fact]
        public void AddParticipantShouldAddParticipantToEvent()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            dbContext.Events.Add(new Event());
            var user = new LessplasticUser
            {
                UserName = "test"
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var testEvent = dbContext.Events.First();

            service.AddParticipant(testEvent, "test");

            Assert.Equal(1, dbContext.UsersEvents.Count());
        }

        [Fact]
        public void GetEventTownsShouldReturnAllTownsForEvent()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Event").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            var model = new EventViewModel
            {
                Name = "test",
                Description = "test",
                EventDate = DateTime.Now,
                Towns = "Burgas, Varna, Sozopol"
            };

            var eventId = service.CreateEvent(model);

            var towns = service.GetEventTowns(eventId);

            Assert.Equal(3, towns.Length);
        }

        [Fact]
        public void GetEventParticipantsShouldReturnAllParticipantsForEvent()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new EventService(dbContext);

            dbContext.Events.Add(new Event());
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

            var testEvent = dbContext.Events.First();

            service.AddParticipant(testEvent, "test");
            service.AddParticipant(testEvent, "test2");

            var participants = service.GetEventParticipants(testEvent.Id);

            Assert.Equal(2, participants.Length);
        }
    }
}
