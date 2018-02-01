using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;

namespace TeknikServis.BLL.Repository
{
  public class SurveyRepo : RepositoryBase<Survey, int>{}
  public class SurveyQuestionRepo : RepositoryBase<SurveyQuestion, int>{}
  public class SurveyAnswerRepo : RepositoryBase<SurveyAnswer, int>{}
  public class FaultRepo : RepositoryBase<Fault, int>{}
  public class FaultStatusRepo : RepositoryBase<FaultStatus, int>{}
  public class PhotoRepo : RepositoryBase<Photo, int>{}
}
