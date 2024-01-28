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
         await _context.Degrees.AddAsync(degree);
         var result = await _context.SaveChangesAsync(token) > 0;

         // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η εισαγωγή του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> UpdateDegree(Guid DegreeId, UpdateDegreeDto dto, CancellationToken token)
      {
         // Searching Item
         var degree = await _context.Degrees.Where(x => x.DegreeId == DegreeId).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         // Mapping and Saving
         dto.UpdateDegreeModelMapping(degree);
         var result = await _context.SaveChangesAsync(token) > 0;

         // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η ενημέρωση του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }

      public async Task<CommandResponse<string>> DeleteDegree(Guid DegreeId, CancellationToken token)
      {
         // Searching Item
         var degree = await _context.Degrees.Where(x => x.DegreeId == DegreeId).FirstOrDefaultAsync(token);

         // Checking for Exceptions
         if (degree is null) throw new Exception("Το πτυχίο δεν βρέθηκε");

         // Deleting
         _context.Degrees.Remove(degree);
         var result = await _context.SaveChangesAsync(token) > 0;

        // Initializing object
         return new CommandResponse<string>()
            .WithSuccess(result)
            .WithData($"Η διαγραφή του πτυχίου με όνομα {degree.Name} ολοκληρώθηκε επιτυχώς");
      }
   }
}