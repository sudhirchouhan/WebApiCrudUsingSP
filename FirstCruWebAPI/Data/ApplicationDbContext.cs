using FirstCruWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FirstCruWebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {     
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
            {

            }
            public DbSet<UserRegistration> tblUsers { get; set; }
            public DbSet<Employee> Employees { get; set; }
    }
}
