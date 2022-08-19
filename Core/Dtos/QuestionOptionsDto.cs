using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class QuestionOptionsDto:BaseDto

    {
        public int QuestionId { get; set; }
        public string Label1 { get; set; }
    }
}
