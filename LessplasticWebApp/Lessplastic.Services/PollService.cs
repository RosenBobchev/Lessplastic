using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Polls;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessplastic.Services
{
    public class PollsService : IPollService
    {
        private ApplicationDbContext context;

        public PollsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddParticipant(Poll poll, string username)
        {
            LessplasticUser user = this.context.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null)
            {
                return false;
            }

            var pollsUsers = new PollsUsers
            {
                LessplasticUser = user,
                LessplasticUserId = user.Id,
                Poll = poll,
                PollId = poll.Id
            };

            user.Pools.Add(pollsUsers);
            poll.Users.Add(pollsUsers);
            this.context.SaveChanges();

            return true;
        }

        public void CreatePoll(PollViewModel model)
        {
            var answersInput = model.Answers.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var poll = new Poll
            {
                Title = model.Title,
                CreatedOn = DateTime.Now,
            };
            
            foreach (var item in answersInput)
            {
                var answer = new Answer
                {
                    Name = item,
                    Poll = poll
                };
                
                poll.Answers.Add(answer);
            }

            this.context.Polls.Add(poll);
            this.context.SaveChanges();
        }

        public void DeletePoll(Poll poll)
        {
            this.context.Remove(poll);
            this.context.SaveChanges();
        }

        public void EditPoll(Poll poll, UpdateDeletePollViewModel model)
        {
            poll.Title = model.Title;

            this.context.SaveChanges();
        }

        public Poll GetPoll(int id)
        {
            var poll = this.context.Polls.Include(x => x.Users).Include(x => x.Answers).FirstOrDefault(x => x.Id == id);

            return poll;
        }

        public Poll[] GetPolls()
        {
            var polls = this.context.Polls.Include(x => x.Users).Include(x => x.Answers).ToArray();

            return polls;
        }

        public PollsUsers[] GetPollsParticipants(int id)
        {
            var users = this.context.PollsUsers.Include(x => x.LessplasticUser).Where(x => x.PollId == id).ToArray();

            return users;
        }

        public Answer[] GetPollsAnswers(int id)
        {
            var answers = this.context.Answers.Where(x => x.PollId == id).ToArray();

            return answers;
        }

        public void IncrementVoters(int pollId, int answerId)
        {
            var poll = this.GetPoll(pollId);
            
            var answer = poll.Answers.FirstOrDefault(x => x.Id == answerId);

            if (answer != null)
            {
                answer.Voters++;
            }

            this.context.SaveChanges();
        }
    }
}
