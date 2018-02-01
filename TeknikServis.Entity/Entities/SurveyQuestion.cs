using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Sorular")]
    public class SurveyQuestion:BaseEntity<int>
    {
        [Required]
        public string QuestionText { get; set; }
        public int SurveyId { get; set; }

        public List<SurveyAnswer> Answers { get; set; } = new List<SurveyAnswer>();
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
    }
}
