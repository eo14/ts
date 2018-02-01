using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.Entities
{
    [Table("SurveyAnswers")]
    public class SurveyAnswer :BaseEntity<int>
    {
        public int? QuestionAnswer { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("QuestionId")]
        public SurveyQuestion Soru { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
