using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Survey : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
