using Application.Candidate;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CandidatesController : ControllerBase
   {
      private readonly ICandidatesService _candidatesService;

      public CandidatesController(ICandidatesService candidatesService)
      {
         _candidatesService = candidatesService;
      }

      [HttpGet]
      public async Task<IActionResult> GetDegreesCandidates(CancellationToken token)
         => Ok(await _candidatesService.GetDegreesCandidates(token));

      [HttpPost]
      public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateDto dto, CancellationToken token)
         => Ok(await _candidatesService.CreateCandidate(dto, token));

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateCandidate(int id,  [FromBody] UpdateCandidateDto dto, CancellationToken token)
        => Ok(await _candidatesService.UpdateCandidate(id, dto, token));

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteCandidate(int id, CancellationToken token)
        => Ok(await _candidatesService.DeleteCandidate(id, token));
   }
}