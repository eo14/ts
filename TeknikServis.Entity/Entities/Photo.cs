using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Photos")]
    public class Photo:BaseEntity<int>
    {
        [Required]
        public string URL { get; set; }
        public int FaultId { get; set; }
        [ForeignKey("FaultId")]
        public Fault Fault { get; set; }
    }
}
