using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Data.Entities
{
    public class Rep
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        //STRETCH GOAL: property that tracks conversions
        //public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();
    }
}
