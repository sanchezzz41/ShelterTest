using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Shelter.Domain.Questionnaires.Models;
using Shelter.Domain.Users.Models;
using Shelter.Entity;

namespace Shelter.Domain
{
    public class AutoMapperService : Profile
    {
        public AutoMapperService()
        {
            CreateMap<User, UserModel>();

            CreateMap<QuestionnaireInfo, Questionnaire>();
            CreateMap<Questionnaire, QuestionnaireModel>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.OwnerUser));

        }
    }
}
