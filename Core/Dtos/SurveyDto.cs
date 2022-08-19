using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class SurveyDto:BaseDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
