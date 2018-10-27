using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Entity
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RoleOption RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public Role()
        {
        }
    }
}
