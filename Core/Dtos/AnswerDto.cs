using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class AnswerDto:BaseDto
    {
        public int ResponseId { get; set; }
        public int QuestionId     { get; set; }
        public int QuestionOptionId { get; set; }
        public int Value { get; set; } 
    }
}
