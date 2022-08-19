using AutoMapper;
using Core.Dtos;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Survey, SurveyDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionOption, QuestionOptionsDto>().ReverseMap();
            CreateMap<Response, ResponsesDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<Survey, SurveyAndQuestionsDto>();
            CreateMap<Question, QuestionWithSurveyDto>();
            CreateMap<Answer, AnswerWithQuestionDto>();
        }
    }
}
