using System;

namespace Shelter.Domain.Questionnaires.Models
{
    /// <summary>
    /// Входящая модель анекет
    /// </summary>
    public class QuestionnaireInfo
    {
        public Guid UserGuid { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public string Sex { get; set; }

        public int Old { get; set; }

        public string Description { get; set; }

        public string Vaccination { get; set; }

        public QuestionnaireInfo()
        {
            
        }
    }
}
