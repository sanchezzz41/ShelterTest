using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Entity
{
    /// <summary>
    /// Анкета
    /// </summary>
    public class Questionnaire
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid QuestionnaireGuid { get; set; }

        [ForeignKey(nameof(OwnerUser))]
        public Guid UserGuid { get; set; }

        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Sex { get; set; }

        [Range(0,100)]
        public int Old { get; set; }

        public string Description { get; set; }

        public string Vaccination { get; set; }

        /// <summary>
        /// Владелец анкеты
        /// </summary>
        public virtual User OwnerUser { get; set; }

        public virtual IList<Comment> Comments { get; set; }

        public Questionnaire()
        {
            QuestionnaireGuid = Guid.NewGuid();
        }
    }
}
