
using Microsoft.EntityFrameworkCore;
using WindGenerator.Models;

namespace WindGenerator {
    public class WindDataDBContext : DbContext {


        public WindDataDBContext(DbContextOptions<WindDataDBContext> options)
            : base(options) {
        }

        public WindDataDBContext(){

        }

        public virtual DbSet<WindDataGenerator> WindDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(Secrets.ConnectionString);
            }
        }




    }
}
