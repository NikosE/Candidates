using Domain.Dto;

namespace Application.Degree
{
   public static class DegreesMapping
   {
      public static Domain.Entities.Degree CreateDegreesModelMapping(this CreateDegreeDto dto) 
      => new ()
      {
         Name = dto.Name,
         CreationTime = DateTime.Now       
      };

      public static void UpdateDegreeModelMapping(this UpdateDegreeDto dto, Domain.Entities.Degree model)
      {
         model.Name = dto.Name;
      }

      public static DegreesCandidatesDto GetCandidateDegreeModelMapping(this Domain.Entities.Degree model)
      => new (
         Name : model.Name
      );

      public static ItemDegreesDto ListDegreeDtoMapping(this Domain.Entities.Degree model)
      => new (
         Id: model.Id,
         Name: model.Name
      );
   }
}