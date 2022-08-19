using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public ICollection<QuestionOption> QuestionOptions { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }

    }
}
