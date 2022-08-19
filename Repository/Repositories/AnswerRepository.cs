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
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Answer>> GetAnswerWithQuestion()
        {
            return await _context.Answers.Include(x => x.Question).ToListAsync();
        }
    }
}
