using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Answer:BaseEntity
    {
        public int Value  { get; set; }

        public Response Response { get; set; }
        public int ResponseId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public QuestionOption QuestionOption { get; set; }
        public int? QuestionOptionId { get; set; }

    }
}
