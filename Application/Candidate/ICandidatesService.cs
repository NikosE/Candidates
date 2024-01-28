using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Candidate
{
   public interface ICandidatesService
   {
      Task<CommandResponse<string>> CreateCandidate (CreateCandidateDto dto, Guid DegreeId, CancellationToken token);
      Task<CommandResponse<string>> UpdateCandidate (Guid CandidateId, string degreeName, UpdateCandidateDto dto, CancellationToken token);
      Task<CommandResponse<string>> DeleteCandidate (Guid CandidateId, CancellationToken token);        
   }
}