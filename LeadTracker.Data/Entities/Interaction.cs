using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTracker.Data.Entities
{
    public enum ContactType
    {
        Phone,
        Email,
        SMS,
        InPerson
    }
    public class Interaction
    {
        [Key]
        public int InteractionID { get; set; }
        public int LeadID { get; set; }
        [ForeignKey(nameof(LeadID))]
        public virtual Lead Lead { get; set; }
        public int RepID { get; set; }
        [ForeignKey(nameof(RepID))]
        public virtual Rep Rep { get; set; }
        [Required]
        [Display(Name = "Type of Contact")]
        public ContactType TypeOfContact { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
