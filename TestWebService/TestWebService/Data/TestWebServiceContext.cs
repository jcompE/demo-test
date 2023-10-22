using Microsoft.EntityFrameworkCore;
using TestWebService.Models;

namespace TestWebService.Data
{
    //DBContext class
    public class TestWebServiceContext : DbContext
    {
        public TestWebServiceContext(DbContextOptions<TestWebServiceContext> options): base(options)
        {

        }
        
        //add the specific database set
        public DbSet<College> Colleges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}