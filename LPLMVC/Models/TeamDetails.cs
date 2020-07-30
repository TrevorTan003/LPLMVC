using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class TeamDetails
    {
        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        /// Players In Team
        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
        [Required]
        public string Player3 { get; set; }
        [Required]
        public string Player4 { get; set; }
        [Required]
        public string Player5 { get; set; }
        [Required]
        public string Player6 { get; set; }
        [Required]
        public string Player7 { get; set; }
        ///Roles
        [Required]
        public TeamPosition teamPosition { get; set; }

        public enum TeamPosition
        {
            Main,
            Substitute
        }
    }
}
