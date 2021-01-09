using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VotingInformation.Contracts.Repositories;
using VotingInformation.Models;

namespace VotingInformation.Services
{
    public class VotingInformationService : IVotingInformationService
    {

        private readonly ILogger<VotingInformationService> _logger;
        private readonly IVotingInformationRepository _votingInformationRepository;

        public VotingInformationService(
            ILogger<VotingInformationService> logger,
            IVotingInformationRepository votingInformationRepository
        )
        {
            _logger = logger;
            _votingInformationRepository = votingInformationRepository;
        }

        public State GetStateInformation(string stateAbbr)
        {
            var stateInformation = _votingInformationRepository.GetStateInformation(stateAbbr);

            var totalMailInVotes = (double)stateInformation.Voters.FindAll(x => x.VoteType == "Mail-In").Count();
            var totalInPersonVotes = (double)stateInformation.Voters.FindAll(x => x.VoteType == "In-Person").Count();
            var totalEarlyVotes = (double)stateInformation.Voters.FindAll(x => x.EarlyVote == true).Count();

            stateInformation.VoterTurnout = stateInformation.Voters.Count();
            stateInformation.ValidVotes = stateInformation.Voters.FindAll(x => x.ValidVote == true).Count();
            stateInformation.MailInVotesPerc = (double)(totalMailInVotes / (double)stateInformation.VoterTurnout * 100);
            stateInformation.InPersonVotesPerc = (double)(totalInPersonVotes / (double)stateInformation.VoterTurnout * 100);
            stateInformation.EarlyVotesPerc = (double)(totalEarlyVotes / (double)stateInformation.VoterTurnout * 100);
            
            return stateInformation;
        }

        public Voter AddVote(string stateAbbr, Voter voterData)
        {
            //TODO: Add Validation
            var stateInfo = GetStateInformation(stateAbbr);
            if (stateInfo.StateId == 0) throw new Exception("StateId Is Invalid");

            
            return _votingInformationRepository.AddVoter(stateInfo.StateId, voterData);
        }


        public Voter UpdateVoteValidity(Voter voterData)
        {
            //TODO: Add Validatiom
            
            return _votingInformationRepository.UpdateVoteValidity(voterData);
        }

    }
}
