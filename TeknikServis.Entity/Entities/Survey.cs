using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Surveys")]
    public class Survey: BaseEntity<int>
    {
        public string SurveyName { get; set; }
        public List<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
        public override string ToString()
        {
            return SurveyName;
        }
    }
}
