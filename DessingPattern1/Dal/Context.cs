using Microsoft.EntityFrameworkCore;

namespace DessingPattern1.Dal
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-H080ONB\\SQLEXPRESS01;initial catalog=DbDessing1;integrated security=true");
        }

        public DbSet<CustomerProcess> CustomerProcesses{ get; set; }    
    }
}
