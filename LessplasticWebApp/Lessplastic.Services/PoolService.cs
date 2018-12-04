using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Pools;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessplastic.Services
{
    public class PoolService : IPoolService
    {
        private ApplicationDbContext context;

        public PoolService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddParticipant(Pool pool, string username)
        {
            LessplasticUser user = this.context.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null)
            {
                return false;
            }

            var poolsUsers = new PoolsUsers
            {
                LessplasticUser = user,
                LessplasticUserId = user.Id,
                Pool = pool,
                PoolId = pool.Id
            };

            user.Pools.Add(poolsUsers);
            pool.Users.Add(poolsUsers);
            this.context.SaveChanges();

            return true;
        }

        public int CreateEvent(PoolViewModel model)
        {
            var answers = model.Answers.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var pool = new Pool
            {
                Title = model.Title,
            };

            foreach (var answer in answers)
            {
                var answerExists = this.context.Answers.FirstOrDefault(x => x.Name == answer);

                if (answerExists != null)
                {
                    PoolsAnswers poolsAnswers = new PoolsAnswers
                    {
                        Answer = answerExists,
                        Pool = pool,
                    };

                    pool.Answers.Add(poolsAnswers);
                    this.context.PoolsAnswers.Add(poolsAnswers);
                    this.context.SaveChanges();
                }
                else
                {
                    Answer newAnswer = new Answer
                    {
                        Name = answer,
                    };

                    PoolsAnswers poolsAnswers = new PoolsAnswers
                    {
                        Answer = newAnswer,
                        Pool = pool,
                    };

                    pool.Answers.Add(poolsAnswers);
                    this.context.Answers.Add(newAnswer);
                    this.context.PoolsAnswers.Add(poolsAnswers);
                    this.context.SaveChanges();
                }
            }
            
            return pool.Id;
        }

        public void DeleteEvent(Pool pool)
        {
            this.context.Remove(pool);
            this.context.SaveChanges();
        }

        public void EditEvent(Pool pool, UpdateDeletePoolViewModel model)
        {
            pool.Title = model.Title;

            this.context.SaveChanges();
        }

        public Pool GetPool(int id)
        {
            var pool = this.context.Pools.Include(x => x.Users).Include(x => x.Answers).FirstOrDefault(x => x.Id == id);

            return pool;
        }

        public Pool[] GetPools()
        {
            var pools = this.context.Pools.Include(x => x.Users).Include(x => x.Answers).ToArray();

            return pools;
        }

        public PoolsUsers[] GetPoolsParticipants(int id)
        {
            var users = this.context.PoolsUsers.Include(x => x.LessplasticUser).Where(x => x.PoolId == id).ToArray();

            return users;
        }

        public PoolsAnswers[] GetPoolsAnswers(int id)
        {
            var answers = this.context.PoolsAnswers.Include(x => x.Answer).Where(x => x.PoolId == id).ToArray();

            return answers;
        }
    }
}
