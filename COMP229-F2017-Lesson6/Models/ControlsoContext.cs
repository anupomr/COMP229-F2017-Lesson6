namespace COMP229_F2017_Lesson6.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ControlsoContext : DbContext
    {
        public ControlsoContext()
            : base("name=ControlsoConnection")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Cours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstMidName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
