using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VotingInformation.Contracts.Repositories;
using VotingInformation.Models;

namespace VotingInformation.Controllers
{
    [ApiController]
    [Route("application")]
    public class VotingInformationController : ControllerBase
    {

        private readonly ILogger<VotingInformationController> _logger;
        private readonly IVotingInformationService _votingInformationService;

        public VotingInformationController(
            ILogger<VotingInformationController> logger,
            IVotingInformationService votingInformationService
        )
        {
            _logger = logger;
            _votingInformationService = votingInformationService;
        }

        [HttpGet("health")]
        public int Get()
        {
            return StatusCodes.Status200OK;;
        }

        [HttpGet("state/{stateAbbreviation}")]
        public State GetState(
            [FromRoute] string stateAbbreviation
        )
        {
            return _votingInformationService.GetStateInformation(stateAbbreviation);
        }

        [HttpPost("state/{stateAbbreviation}/addVote")]
        public Voter AddVote(
            [FromRoute] string stateAbbreviation,
            [FromBody] Voter request
        )
        {
            return _votingInformationService.AddVote(stateAbbreviation, request);
        }

        [HttpPut("updateVoteValidity")]
        public Voter UpdateVoteValidity(
            [FromBody] Voter request
        )
        {
            return _votingInformationService.UpdateVoteValidity(request);
        }
    }
}
