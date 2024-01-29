namespace Domain.Dto
{
   public record CreateDegreeDto(string Name);

   public record UpdateDegreeDto(string Name);

   public record DegreesCandidatesDto(string Name);

   public record ItemDegreesDto(int Id, string Name);
}