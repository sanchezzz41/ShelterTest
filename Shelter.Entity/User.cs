using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Entity
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserGuid { get; set; }

        [ForeignKey(nameof(Role))]
        public RoleOption RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public virtual Role Role { get; set; }

        public User()
        {
            UserGuid = Guid.NewGuid();
        }
    }
}
