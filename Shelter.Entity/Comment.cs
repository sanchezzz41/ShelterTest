using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Entity
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CommentGuid { get; set; }

        [ForeignKey(nameof(Questionnaire))]
        public Guid QuestionnaireGuid { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserGuid { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public DateTimeOffset CratedDate { get; set; }

        /// <summary>
        /// Анкета
        /// </summary>
        public virtual Questionnaire Questionnaire { get; set; }

        /// <summary>
        /// Анкета
        /// </summary>
        public virtual User User { get; set; }

        public Comment()
        {
        }
    }
}
