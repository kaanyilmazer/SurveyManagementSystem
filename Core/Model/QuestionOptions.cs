using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class QuestionOption : BaseEntity
    {
        public string Label { get; set; }
      
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
