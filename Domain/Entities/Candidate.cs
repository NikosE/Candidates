using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public class Candidate
    {
      #region Properties
      [Key]
      public int Id { get; set; }
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
      public string Mobile { get; set; }
      public byte[] CV { get; set; }
      public DateTime CreationTime { get; set; }
      #endregion

      #region Foreign Key
      public int DegreeId { get; set; }
      #endregion

      #region Navigation Properties
      public Degree Degree { get; set; }
      #endregion
    }
}