using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.Entities
{
    [Table("Faults")]
    public class Fault:BaseEntity<int>
    {
        [Required]
        public string Description { get; set; }
        public string UserId { get; set; }
        public string OperatorId { get; set; }
        public string TechnicianId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Report { get; set; }
        [Required]
        public string Location { get; set; }
        public string AddressDescription { get; set; }


        public List<FaultStatus> Statuses { get; set; } = new List<FaultStatus>();
        public List<Photo> Photos { get; set; } = new List<Photo>();
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("OperatorId")]
        public ApplicationUser Operator { get; set; }
        [ForeignKey("TechnicianId")]
        public ApplicationUser Technician { get; set; }

    }
}
