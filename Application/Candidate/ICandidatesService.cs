using Domain.Dto;
using Domain.Dto.Common;

namespace Application.Candidate
{
   public interface ICandidatesService
   {
      Task<Response<List<DegreesCandidatesDto>>> GetDegreesCandidates(CancellationToken token);
      
      Task<Response<string>> CreateCandidate (CreateCandidateDto dto, CancellationToken token);
      
      Task<Response<string>> UpdateCandidate (int id, UpdateCandidateDto dto, CancellationToken token);
      
      Task<Response<string>> DeleteCandidate (int id, CancellationToken token);        
   }
}