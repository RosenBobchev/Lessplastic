using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Polls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Services.Contracts
{
    public interface IPollService
    {
        Poll GetPoll(int id);

        Poll[] GetPolls();

        void CreatePoll(PollViewModel model);

        void EditPoll(Poll poll, UpdateDeletePollViewModel model);

        void DeletePoll(Poll poll);
        
        PollsUsers[] GetPollsParticipants(int id);

        bool AddParticipant(Poll poll, string username);

        Answer[] GetPollsAnswers(int id);

        void IncrementVoters(int pollId, int answerId);
    }
}
