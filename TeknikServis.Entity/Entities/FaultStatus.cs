using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Enums;

namespace TeknikServis.Entity.Entities
{
    [Table("FaultStatuses")]
    public class FaultStatus:BaseEntity<int>
    {
        public int FaultId { get; set; }
        [Required]
        public FaultStatus Status { get; set; }
        public string Description { get; set; }

        [ForeignKey("FaultId")]
        public Fault Fault { get; set; }

    }
}
