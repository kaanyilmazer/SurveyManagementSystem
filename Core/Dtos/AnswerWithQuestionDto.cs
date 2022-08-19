using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AnswerWithQuestionDto : AnswerDto
    {
        public QuestionDto Question { get; set; }
    }
}
