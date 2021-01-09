using Microsoft.Extensions.Logging;
using VotingInformation.Contracts.Repositories;
using VotingInformation.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using VotingInformation.Services;
using System;
using System.Collections.Generic;

namespace VotingInformation.Repositories
{
    public class VotingInformationRepository : IVotingInformationRepository
    {

        private readonly ILogger<VotingInformationService> _logger;

        public VotingInformationRepository(ILogger<VotingInformationService> logger)
        {
            _logger = logger;
        }

        public State GetStateInformation(string stateAbbr)
        {
            State state = new State();
            var query = ExcuteSelect(@"
                SELECT
                    *
                FROM
                    VotingInformation.State
                WHERE
                    Abbreviation ='" + stateAbbr + "' LIMIT 1");

            while (query.Read())
            {
                state.StateId = Int32.Parse(query["StateId"]?.ToString());
                state.StateName = query["StateName"]?.ToString();
                state.Abbreviation = query["Abbreviation"]?.ToString();
                state.RegisteredVoters = Int32.Parse(query["RegisteredVoters"]?.ToString());
            }
            query.Close();

            var voters = GetVoterInformation(state.StateId);
            state.Voters = voters;

            return state;
        }

        public List<Voter> GetVoterInformation(int stateId)
        {
            List<Voter> voters = new List<Voter>();
            var query = ExcuteSelect(@"
                SELECT
                    *
                FROM
                    VotingInformation.Voter
                WHERE
                    StateId =" + stateId);

            while (query.Read())
            {
                var voter = new Voter
                {
                    VoterId = Int32.Parse(query["VoterId"]?.ToString()),
                    StateId = Int32.Parse(query["StateId"]?.ToString()),
                    EarlyVote = (bool)query["EarlyVote"],
                    VoteType = query["VoteType"]?.ToString(),
                    ValidVote = (bool)query["ValidVote"],
                    SSN = Int32.Parse(query["SSN"]?.ToString()),
                };

                voters.Add(voter);
            }
            query.Close();

            
            
            return voters;
        }

        public Voter AddVoter(int stateId, Voter voterInfo)
        {
            // Check if voter doesn't exists
            var checkVoter = GetIndividualVoterInfo(voterInfo.SSN);
            if (checkVoter.VoterId != 0) throw new Exception("Voter data already exists");

            string queryInsert = @"
                INSERT INTO
                    VotingInformation.Voter 
                        (StateId, EarlyVote, VoteType, ValidVote, SSN)
                    VALUES
                        (" + voterInfo.StateId + ", " + voterInfo.EarlyVote + ", '" + voterInfo.VoteType + "'," + voterInfo.ValidVote + ", " + voterInfo.SSN + ");";

            try{
                ExcuteInsertOrUpdate(queryInsert);
            }
            catch
            {
                // unneeded
                throw new Exception("Unable to insert");
            }

            return GetIndividualVoterInfo(voterInfo.SSN);
        }

        public Voter UpdateVoteValidity(Voter voterInfo)
        {
            // Check if voter doesn't exists
            var checkVoter = GetIndividualVoterInfo(voterInfo.SSN);
            if (checkVoter.VoterId == 0) throw new Exception("Voter doesn't exists");

            string queryUpdate = "UPDATE VotingInformation.Voter SET ValidVote = " + voterInfo.ValidVote + " WHERE SSN = " + voterInfo.SSN;

            try{
                ExcuteInsertOrUpdate(queryUpdate);
            }
            catch
            {
                // unneeded
                throw new Exception("Unable to insert");
            }

            return GetIndividualVoterInfo(voterInfo.SSN);
        }

        public Voter GetIndividualVoterInfo(int SSN)
        {
            var voter = new Voter{};

            var query = ExcuteSelect(@"
                SELECT
                    *
                FROM
                    VotingInformation.Voter
                WHERE
                    SSN =" + SSN + " LIMIT 1");

            while (query.Read())
            {
                voter.VoterId = Int32.Parse(query["VoterId"]?.ToString());
                voter.StateId = Int32.Parse(query["StateId"]?.ToString());
                voter.EarlyVote = (bool)query["EarlyVote"];
                voter.VoteType = query["VoteType"]?.ToString();
                voter.ValidVote = (bool)query["ValidVote"];
                voter.SSN = Int32.Parse(query["SSN"]?.ToString());
            }
            query.Close();
            
            return voter;
        }

        private void ExcuteInsertOrUpdate(string query)
        {
            var cmd =  new MySqlCommand(query,GetDBConnection());
            cmd.ExecuteNonQuery();
        }
        private MySqlDataReader ExcuteSelect(string query)
        {
            return new MySqlCommand(query,GetDBConnection()).ExecuteReader();
        }

        private MySqlConnection GetDBConnection()
        {

            string connStr = "server=127.0.0.1;user=admin;password=secret;database=VotingInformation";
            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = connStr;
            conn.Open();

            return conn; 
        }

    }
}
