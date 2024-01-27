namespace Domain.Dto
{
   public record CreateCandidateDto
   (
      string LastName,
      string FirstName,
      string Email,
      int Mobile,
      string Degree,
      byte[] CV
   );

   public record UpdateCandidateDto
   (
      string LastName,
      string FirstName,
      string Email,
      int Mobile,
      string Degree,
      byte[] CV
   );

   public record ItemCandidateDto
   (
      string LastName,
      string FirstName,
      string Email,
      int Mobile,
      string Degree,
      byte[] CV,
      DateTime CreationTime
   );

public record ListItemCandidateDto
   (
      Guid CandidateId,
      string LastName,
      string FirstName,
      string Email,
      int Mobile,
      string Degree,
      byte[] CV,
      DateTime CreationTime
   );
}