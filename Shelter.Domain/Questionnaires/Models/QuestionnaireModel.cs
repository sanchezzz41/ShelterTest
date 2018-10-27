using System;
using System.Collections.Generic;
using System.Text;
using Shelter.Entity;

namespace Shelter.Domain.Questionnaires.Models
{
    public class QuestionnaireModel
    {
        public User User { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public string Sex { get; set; }

        public int Old { get; set; }

        public string Description { get; set; }

        public string Vaccination { get; set; }

        public QuestionnaireModel()
        {

        }
    }
}
