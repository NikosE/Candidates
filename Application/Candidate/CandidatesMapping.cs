using Domain.Dto;
using Domain.Entities;

namespace Application.Candidate
{
   public static class CandidatesMapping
   {
      public static Candidates CreateCandidateModelMapping(this CreateCandidateDto dto, Degrees model) 
      => new Candidates()
      {
         LastName = dto.LastName,
         FirstName = dto.FirstName,
         Email = dto.Email,
         Mobile = dto.Mobile,
         Degree = model.Name,
         CV = dto.CV,
         CreationTime = DateTime.Now
      };

      public static void UpdateCandidateModelMapping(this UpdateCandidateDto dto, Candidates modelCandidate, Degrees modelDegree)
      {
         modelCandidate.LastName = dto.LastName;
         modelCandidate.FirstName = dto.FirstName;
         modelCandidate.Email = dto.Email;
         modelCandidate.Mobile = dto.Mobile;
         modelCandidate.Degree = modelDegree.Name;
         modelCandidate.CV = dto.CV;
      }        
   }
}