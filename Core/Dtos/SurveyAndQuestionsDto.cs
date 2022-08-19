using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class SurveyAndQuestionsDto:SurveyDto
    {
        public List<QuestionDto> Questions { get; set; }
    }
}
