using Application.Degree;
using Application.Validators;
using Domain.Dto;
using Domain.Dto.Common;
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

      public async Task<Response<List<DegreesCandidatesDto>>> GetDegreesCandidates(CancellationToken token)
      {
         var candidatesDegrees = await _context.Candidates.Include(x => x.Degree).ToListAsync(token);

         var degrees = candidatesDegrees.Select(x => x.Degree).ToList();

         var dto = degrees.Select(x => x.GetCandidateDegreeModelMapping()).ToList();

         return new Response<List<DegreesCandidatesDto>>().WithData(dto);
      }

      public async Task<Response<string>> CreateCandidate(CreateCandidateDto dto, CancellationToken token)
      {
         var validator = new CreateCandidateDtoValidator();
         var validationResult = validator.Validate(dto);

         if (!validationResult.IsValid)
         {
            // Concatenate error messages from validation results
            string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
            return new Response<string>().WithData(errorMessage);
         }


         // Searching Degree
         var degree = await _context.Degrees.SingleOrDefaultAsync(x => x.Id == dto.DegreeId, cancellationToken: token);
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         //Mapping and Saving
         var candidate = dto.CreateCandidateModelMapping(degree);
         await _context.Candidates.AddAsync(candidate, cancellationToken: token);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής αποθήκευση υποψηφίου");

         // Initializing object
         return new Response<string>()
            .WithData($"Η εισαγωγή του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<Response<string>> UpdateCandidate(int id, UpdateCandidateDto dto, CancellationToken token)
      {
         var validator = new UpdateCandidateDtoValidator();
         var validationResult = validator.Validate(dto);

         if (!validationResult.IsValid)
         {
            // Concatenate error messages from validation results
            string errorMessage = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
            return new Response<string>().WithData(errorMessage);
         }

         // Searching Item
         var candidate = await _context.Candidates.Where(x => x.Id == id).SingleOrDefaultAsync(token);

         // Checking for Exceptions
         if (candidate is null) throw new Exception("Ο υποψήφιος δεν βρέθηκε");

         // Searching Item
         var degree = await _context.Degrees.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: token);

         // Checking for Exceptions
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         // Mapping and Saving
         dto.UpdateCandidateModelMapping(candidate, degree);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής ενημέρωση υποψηφίου");

         // Initializing object
         return new Response<string>()
            .WithData($"Η ενημέρωση του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<Response<string>> DeleteCandidate(int id, CancellationToken token)
      {
         // Searching Item
         var candidate = await _context.Candidates.Where(x => x.Id == id).SingleOrDefaultAsync(token);

         // Checking for Exceptions
         if (candidate is null) throw new Exception("Ο υποψήφιος δεν βρέθηκε");

         // Deleting
         _context.Candidates.Remove(candidate);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής διαγραφή υποψηφίου");

        // Initializing object
         return new Response<string>()
            .WithData($"Η διαγραφή του υποψήφιου με όνομα {candidate.FirstName} {candidate.LastName} ολοκληρώθηκε επιτυχώς");
      }
   }
}