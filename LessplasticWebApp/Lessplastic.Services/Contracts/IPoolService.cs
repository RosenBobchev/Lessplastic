using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Pools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Services.Contracts
{
    public interface IPoolService
    {
        Pool GetPool(int id);

        Pool[] GetPools();

        int CreateEvent(PoolViewModel model);

        void EditEvent(Pool pool, UpdateDeletePoolViewModel model);

        void DeleteEvent(Pool pool);
        
        PoolsUsers[] GetPoolsParticipants(int id);

        bool AddParticipant(Pool pool, string username);

        PoolsAnswers[] GetPoolsAnswers(int id);
    }
}
