using System;
using Shelter.Entity;

namespace Shelter.Domain.Users.Models
{
    public class UserModel
    {
        public Guid UserGuid { get; set; }

        public RoleOption RoleId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserModel()
        {
            
        }
    }
}
