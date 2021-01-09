using System.Collections.Generic;

namespace VotingInformation.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Abbreviation { get; set; }
        public int RegisteredVoters { get; set; }
        public List<Voter> Voters { get; set; }
        public int VoterTurnout { get; set; }// To be calculated
        public int ValidVotes { get; set; }// To be calculated
        public double MailInVotesPerc { get; set; }// To be calculated
        public double InPersonVotesPerc { get; set; }// To be calculated
        public double EarlyVotesPerc { get; set; }// To be calculated
    }
}