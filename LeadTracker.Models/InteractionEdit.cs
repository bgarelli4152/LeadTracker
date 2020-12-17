using LeadTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LeadTracker.Models
{
    public class InteractionEdit
    {
        public int InteractionID { get; set; }
        [Required]
        [Display(Name = "Type of Contact")]
        public ContactType TypeOfContact { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
