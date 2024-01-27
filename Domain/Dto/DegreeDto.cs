namespace Domain.Dto
{
   public record DegreeDto
   (
      string Name
   );

   public record ItemDegreeDto
   (
      string Name,      
      DateTime CreationTime
   );

public record ListItemDegreeDto
   (
      Guid DegreeId,
      string Name,      
      DateTime CreationTime
   );
}