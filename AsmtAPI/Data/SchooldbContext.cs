using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AsmtAPI.Models;

namespace AsmtAPI.Data;

public partial class SchooldbContext : DbContext
{

    public DbSet<Student> Student { get; set; } = null!;

    public DbSet<Grade> Grade { get; set; } = null!;

    private readonly IConfiguration configuration;

    public SchooldbContext(DbContextOptions<SchooldbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConStrings");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Grade>().HasOptional(grade => grade.student).withRequired(st => st.Grade);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    //Below is for DateOnly
    // protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    // {
    //     builder.Properties<DateOnly>()
    //         .HaveConversion<DateOnlyConverter>()
    //         .HaveColumnType("date");
    // }
    // public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    // {
    //     public DateOnlyConverter() : base(
    //             d => d.ToDateTime(TimeOnly.MinValue),
    //             d => DateOnly.FromDateTime(d))
    //     { }
    // }

    // public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    // {
    //     public DateOnlyConverter() : base(
    //             dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
    //             dateTime => DateOnly.FromDateTime(dateTime))
    //     {
    //     }
    // }

    // public class DateOnlyComparer : ValueComparer<DateOnly>
    // {
    //     public DateOnlyComparer() : base(
    //         (d1, d2) => d1.DayNumber == d2.DayNumber,
    //         d => d.GetHashCode())
    //     {
    //     }
    // }

}


