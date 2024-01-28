using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public class Candidates
    {
      #region Properties
      [Key]
      public Guid CandidateId { get; set; }
      [Required]
      [MaxLength(40)]
      public string LastName { get; set; }
      [Required]
      [MaxLength(40)]
      public string FirstName { get; set; }
      [Required]
      [MaxLength(50)]
      public string Email { get; set; }
      [MaxLength(10)]
      public int Mobile { get; set; }
      public string Degree { get; set; }
      public byte[] CV { get; set; }
      public DateTime CreationTime { get; set; }

      #endregion

      #region Navigation Properties
      public ICollection<Degrees> Degrees { get; set; }
      
      #endregion
    }
}