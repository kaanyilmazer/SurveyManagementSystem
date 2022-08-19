using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Response : BaseEntity
    {
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public DateTime SubmittedDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
