using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityVersion2.Web.Models;

namespace UniversityVersion2.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UniversityVersion2.Web.Models.Employee> Employees { get; set; }
        public DbSet<EmpDepartment> Departments { get; set; }
    }
}
