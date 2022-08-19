using Core.Model;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Question>> GetQuestionsWithSurvey()
        {
            return await _context.Questions.Include(x => x.Survey).ToListAsync();
        }
    }
}
