using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Models
{
    public class RepDetail
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}
