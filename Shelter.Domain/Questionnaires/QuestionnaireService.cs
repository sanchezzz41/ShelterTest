using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shelter.Database;
using Shelter.Domain.Questionnaires.Models;
using Shelter.Entity;

namespace Shelter.Domain.Questionnaires
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly DatabaseContext _context;

        public QuestionnaireService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Guid> Create(QuestionnaireInfo model)
        {
            var result = Mapper.Map<QuestionnaireInfo, Questionnaire>(model);
            _context.Questionnaires.Add(result);
            await _context.SaveChangesAsync();
            return result.QuestionnaireGuid;
        }

        /// <inheritdoc />
        public async Task Edit(Guid questionnaireGUid, QuestionnaireInfo model)
        {
            var result = await _context.Questionnaires.SingleAsync(x => x.QuestionnaireGuid == questionnaireGUid);
            Mapper.Map(model, result);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task Delete(Guid questionnaireGUid)
        {
            var result = await _context.Questionnaires.SingleAsync(x => x.QuestionnaireGuid == questionnaireGUid);
            _context.Questionnaires.Remove(result);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public IQueryable<QuestionnaireModel> Get(string search)
        {
            var result = _context.Questionnaires.AsNoTracking();
            return result.ProjectTo<QuestionnaireModel>();
        }
    }
}
