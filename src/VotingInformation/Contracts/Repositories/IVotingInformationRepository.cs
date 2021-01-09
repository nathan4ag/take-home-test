using VotingInformation.Models;

namespace VotingInformation.Contracts.Repositories
{
    public interface IVotingInformationRepository
    {
        State GetStateInformation(string stateAbbr);
        Voter AddVoter(int stateId, Voter voterInfo);
        Voter UpdateVoteValidity(Voter voterInfo);
    }
}