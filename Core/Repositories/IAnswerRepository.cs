using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<List<Answer>> GetAnswerWithQuestion();
    }
}
