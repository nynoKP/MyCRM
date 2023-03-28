using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCRM.Models
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual CRMUser? Sender { get; set; }
        public virtual CRMUser? Recipient { get; set; }
        public string? Message { get; set; }
        public DateTime? Created { get; set; }
    }
}
