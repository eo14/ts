using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.DAL
{
    public class MyContext:IdentityDbContext<ApplicationUser>
    {
        public MyContext():base("name=mycon")
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<FaultStatus> FaultStatuses { get; set; }
    }
}
