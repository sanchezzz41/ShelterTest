using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shelter.Domain.Questionnaires;
using Shelter.Domain.Questionnaires.Models;
using Shelter.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shelter.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Questionnaires")]
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaire;

        public QuestionnaireController(IQuestionnaireService questionnaire)
        {
            _questionnaire = questionnaire;
        }

        [HttpPost]
        [Authorize(Roles = nameof(RoleOption.Admin))]
        public async Task<Guid> Create(QuestionnaireInfo model)
        {
            return await _questionnaire.Create(model);
        }

        [HttpPut("{questionnaireGuid}")]
        [Authorize(Roles = nameof(RoleOption.Admin))]
        public async Task Edit(Guid questionnaireGuid, QuestionnaireInfo model)
        {
             await _questionnaire.Edit(questionnaireGuid,model);
        }

        [HttpGet]
        public async Task<List<QuestionnaireModel>> Get()
        {
            return await _questionnaire.Get("").ToListAsync();
        }
    }
}
