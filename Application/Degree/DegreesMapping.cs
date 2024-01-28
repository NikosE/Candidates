using Domain.Dto;
using Domain.Entities;

namespace Application.Degree
{
   public static class DegreesMapping
   {
      public static Degrees CreateDegreesModelMapping(this CreateDegreeDto dto) 
      => new Degrees()
      {
         Name = dto.Name,
         CreationTime = DateTime.Now       
      };

      public static void UpdateDegreeModelMapping(this UpdateDegreeDto dto, Degrees model)
      {
         model.Name = dto.Name;
      }
      
   }
}