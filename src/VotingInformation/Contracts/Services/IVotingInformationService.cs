using VotingInformation.Models;

namespace VotingInformation.Contracts.Repositories
{
    public interface IVotingInformationService
    {
        State GetStateInformation(string stateAbbr);
        Voter AddVote(string stateAbbr, Voter voterData);
        Voter UpdateVoteValidity(Voter voterData);
    }
}