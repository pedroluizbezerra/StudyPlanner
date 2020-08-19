using Microsoft.EntityFrameworkCore;
using StudyPlanner.Business.Models;
using System.Linq;

namespace StudyPlanner.Data.Context
{
    public class StudyPlannerContext : DbContext
    {
        public StudyPlannerContext(DbContextOptions<StudyPlannerContext> options) : base(options) {}

        public DbSet<Conhecimento> Conhecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudyPlannerContext).Assembly);

            //Para evitar o delede cascade como default
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
