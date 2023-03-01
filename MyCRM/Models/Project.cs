using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCRM.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual CRMUser Creator { get; set; }
        public virtual CRMUser? Responsible { get; set; }
        [Required]
        public virtual Contragent? Customer { get; set; }
    }
}
