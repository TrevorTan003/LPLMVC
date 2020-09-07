using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class TeamSubstituteModel
    {
        [Column(TypeName = "varchar(250)")]
        [DisplayName("SteamID 6")]
        public string Player6 { get; set; }

        [Column(TypeName = "varchar(250)")]
        [DisplayName("SteamID 7")]
        public string Player7 { get; set; }
    }
}
