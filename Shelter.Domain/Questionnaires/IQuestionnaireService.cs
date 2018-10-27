using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shelter.Domain.Questionnaires.Models;

namespace Shelter.Domain.Questionnaires
{
    /// <summary>
    /// Сервис для анкет
    /// </summary>
    public interface IQuestionnaireService
    {
        /// <summary>
        /// Создаёт анкету
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> Create(QuestionnaireInfo model);

        /// <summary>
        /// Изменение анкеты
        /// </summary>
        /// <param name="questionnaireGUid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Edit(Guid questionnaireGUid, QuestionnaireInfo model);

        /// <summary>
        /// Удаление анкеты
        /// </summary>
        /// <param name="questionnaireGUid"></param>
        /// <returns></returns>
        Task Delete(Guid questionnaireGUid);

        /// <summary>
        /// Возвращает заявки
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        IQueryable<QuestionnaireModel> Get(string search);
    }
}
