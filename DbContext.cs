using Microsoft.EntityFrameworkCore;

public class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=CodeFirstPosDB;User Id=sa;Password=Dd466578;TrustServerCertificate=True;"
                    );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId);
            entity.Property(e => e.Name).HasMaxLength(120);
            entity.Property(e => e.Age);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.CourseId);
        });

    
    }


}

