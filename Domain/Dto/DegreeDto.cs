namespace Domain.Dto
{
   public record CreateDegreeDto
   (
      string Name,      
      DateTime CreationTime
   );

   public record UpdateDegreeDto
   (
      string Name
   );
}