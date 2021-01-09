namespace VotingInformation.Models
{
    public class Voter
    {
        public int VoterId { get; set; }
        public int StateId { get; set; }
        public bool EarlyVote { get; set; }
        public string VoteType { get; set; }
        public bool ValidVote { get; set; }
        public int SSN { get; set; }// probably a better way around this but I need a unique identifier for now

    }
}