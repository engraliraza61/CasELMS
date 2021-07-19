using CasELMS.DbClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.Context
{
    public class ProjectContext: DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        public DbSet<StudentRegistration> StudentRegistration { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Permissions> Permission { get; set; }  
        public DbSet<Roles> Role { get; set; }
        public DbSet<PermissionAssignToRoles> PermissionAssignToRole { get; set; }
    }
}
