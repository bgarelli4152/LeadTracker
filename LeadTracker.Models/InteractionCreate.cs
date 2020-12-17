using LeadTracker.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeadTracker.Models
{
    public class InteractionCreate
    {
        [Required]
        public int LeadID { get; set; }
        [Required]
        public int RepID { get; set; }
        [Required]
        [Display(Name = "Type of Contact")]
        public ContactType TypeOfContact { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
