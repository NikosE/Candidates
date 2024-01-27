using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public class Degrees
    {
      #region Properties
      [Key]
      public Guid DegreeId { get; set; }
      [Required]
      [MaxLength(100)]
      public string Name { get; set; }
      public DateTime CreationTime { get; set; }
            
      #endregion

      #region Navigation Properties
      public ICollection<Candidates> Candidates { get; set; }

      #endregion
    }
}