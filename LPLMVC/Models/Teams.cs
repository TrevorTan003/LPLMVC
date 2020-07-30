using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class Teams
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
    }
}
