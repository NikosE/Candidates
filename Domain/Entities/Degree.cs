using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public class Degree
    {
      #region Properties
      [Key]
      public int Id { get; set; }
      [Required]
      [MaxLength(100)]
      public string Name { get; set; }
      public DateTime CreationTime { get; set; }
            
      #endregion

      #region Navigation Properties
      public ICollection<Candidate> Candidates { get; set; }

      #endregion
    }
}