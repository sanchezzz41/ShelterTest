using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shelter.Entity;

namespace Shelter.Database
{
    public class DatabaseInitialize
    {
        private readonly DatabaseContext _context;

        public DatabaseInitialize(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Create()
        {
            await AddRoles();
        }

        public async Task AddRoles()
        {
            if (!await _context.Roles.AnyAsync(x => x.RoleId == RoleOption.Admin))
            {
                _context.Roles.Add(new Role
                {
                    Name = "Admin",
                    RoleId = RoleOption.Admin
                });
            }

            if (!await _context.Roles.AnyAsync(x => x.RoleId == RoleOption.User))
            {
                _context.Roles.Add(new Role
                {
                    Name = "User",
                    RoleId = RoleOption.User
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
