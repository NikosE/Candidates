using Domain.Dto;
using Domain.Dto.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Degree
{
   public class DegreesService : IDegreesService
   {
      private readonly DataContext _context;
      public DegreesService(DataContext context)
      {
         _context = context;
      }

      public async Task<CommandResponse<string>> CreateDegree(CreateDegreeDto dto, CancellationToken token)
      {
         //Mapping and Saving
         var degree = dto.CreateDegreesModelMapping();
         await _context.Degrees.AddAsync(degree, cancellationToken: token);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής αποθήκευση πτυχίου");

         // Initializing object
         return new CommandResponse<string>()
            .WithData($"Η εισαγωγή του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> UpdateDegree(int Id, UpdateDegreeDto dto, CancellationToken token)
      {
         // Searching Item
         var degree = await _context.Degrees.Where(x => x.Id == Id).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         // Mapping and Saving
         dto.UpdateDegreeModelMapping(degree);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής ενημέρωση πτυχίου");

         // Initializing object
         return new CommandResponse<string>()
            .WithData($"Η ενημέρωση του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> DeleteDegree(int Id, CancellationToken token)
      {
         // Searching Item
         var degree = await _context.Degrees.Where(x => x.Id == Id).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         // Deleting
         _context.Degrees.Remove(degree);
         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής διαγραφή πτυχίου");

        // Initializing object
         return new CommandResponse<string>()
            .WithData($"Η διαγραφή του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> ClearDegrees(CancellationToken token)
      {
         var degrees = await _context.Degrees.ToListAsync(token);

         foreach (var degree in degrees)
         {
            var degreeCandidate = await _context.Candidates
               .Where(x => x.DegreeId == degree.Id)
               .FirstOrDefaultAsync(token);

            if (degreeCandidate is null)
             _context.Degrees.Remove(degree);
         }

         var result = await _context.SaveChangesAsync(token) > 0;

         if (!result) throw new Exception("Ανεπιτυχής διαγραφή πτυχίων");

         // Initializing object
         return new CommandResponse<string>()
            .WithData($"Η εκαθάριση των πτυχίων ολοκληρώθηκε επιτυχώς");
      }     
   }
}