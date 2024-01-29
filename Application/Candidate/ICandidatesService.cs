using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Candidate
{
   public interface ICandidatesService
   {
      Task<ListResponse<List<DegreesCandidatesDto>>> GetDegreesCandidates(CancellationToken token);
      
      Task<CommandResponse<string>> CreateCandidate (CreateCandidateDto dto, CancellationToken token);
      
      Task<CommandResponse<string>> UpdateCandidate (int id, UpdateCandidateDto dto, CancellationToken token);
      
      Task<CommandResponse<string>> DeleteCandidate (int id, CancellationToken token);        
   }
}