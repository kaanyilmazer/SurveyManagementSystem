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
    public class SurveyRepository : GenericRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Survey> GetSurveyByIdQuestionAsync(int surveyId)
        {
            return await _context.Surveys.Include(x => x.Questions).Where(x => x.Id == surveyId).SingleOrDefaultAsync();
        }
    }
}
