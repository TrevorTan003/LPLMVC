using LPLMVC.Areas.Identity.Pages.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class TeamDataModel
    {
        /// 
        /// Columns
        /// 
        [Key]
        public int TeamId { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        /// Players In Team
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player1 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player2 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player3 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player4 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player5 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player6 { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Player7 { get; set; }     
        public int Wins { get; set; }
        public int Games { get; set; }

    }
}
