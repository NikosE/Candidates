namespace Domain.Dto
{
   public record CreateCandidateDto
   (
      string LastName,
      string FirstName,
      string Email,
      string Mobile,
      int DegreeId,
      byte[] CV
   );

   public record UpdateCandidateDto
   (
      string LastName,
      string FirstName,
      string Email,
      string Mobile,
      int DegreeId,
      byte[] CV
   );
}