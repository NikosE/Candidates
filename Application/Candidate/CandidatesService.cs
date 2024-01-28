using Domain.Dto;
using Domain.Dto.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Candidate
{
   public class CandidatesService : ICandidatesService
   {
      private readonly DataContext _context;
      public CandidatesService(DataContext context)
      {
         _context = context;
         
      }

      public async Task<CommandResponse<string>> CreateCandidate(CreateCandidateDto dto,Guid DegreeId, CancellationToken token)
      {
         // Searching Degree
         var degree = await _context.Degrees.SingleOrDefaultAsync(x => x.DegreeId == DegreeId);
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         //Mapping and Saving
         var candidate = dto.CreateCandidateModelMapping(degree);
         await _context.Candidates.AddAsync(candidate);
         var result = await _context.SaveChangesAsync(token) > 0;

         // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η εισαγωγή του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> UpdateCandidate(Guid CandidateId, string degreeName, UpdateCandidateDto dto, CancellationToken token)
      {
         // Searching Item
         var candidate = await _context.Candidates.Where(x => x.CandidateId == CandidateId).Include(x => x.Degree).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (candidate is null) throw new Exception("Ο υποψήφιος δεν βρέθηκε");

         // Mapping and Saving
         dto.UpdateCandidateModelMapping(candidate);
         var result = await _context.SaveChangesAsync(token) > 0;

         // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η ενημέρωση του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> DeleteCandidate(Guid CandidateId, CancellationToken token)
      {
         // Searching Item
         var candidate = await _context.Candidates.Where(x => x.CandidateId == CandidateId).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (candidate is null) throw new Exception("Ο υποψήφιος δεν βρέθηκε");

         // Deleting
         _context.Candidates.Remove(candidate);
         var result = await _context.SaveChangesAsync(token) > 0;

        // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η διαγραφή του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }      
   }
}