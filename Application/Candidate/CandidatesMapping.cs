using Domain.Dto;

namespace Application.Candidate
{
   public static class CandidatesMapping
   {
      public static Domain.Entities.Candidate CreateCandidateModelMapping(this CreateCandidateDto dto, Domain.Entities.Degree model) 
      => new ()
      {
         LastName = dto.LastName,
         FirstName = dto.FirstName,
         Email = dto.Email,
         Mobile = dto.Mobile,
         DegreeId = model.Id,
         Degree = model,
         CV = dto.CV,
         CreationTime = DateTime.Now
      };

      public static void UpdateCandidateModelMapping(this UpdateCandidateDto dto, Domain.Entities.Candidate modelCandidate, Domain.Entities.Degree modelDegree)
      {
         modelCandidate.LastName = dto.LastName;
         modelCandidate.FirstName = dto.FirstName;
         modelCandidate.Email = dto.Email;
         modelCandidate.Mobile = dto.Mobile;
         modelCandidate.DegreeId = modelDegree.Id;
         modelCandidate.Degree = modelDegree;
         modelCandidate.CV = dto.CV;
      }        
   }
}