using Microsoft.EntityFrameworkCore;
using OskinAndreiKt_42_20.Database.Configurations;
using OskinAndreiKt_42_20.Models;

namespace OskinAndreiKt_42_20.Database
{

    public class PrepodDbContext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Degree> Degree { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
            modelBuilder.ApplyConfiguration(new KafedraConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
        }
        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options)
        {
        }
    }
}
