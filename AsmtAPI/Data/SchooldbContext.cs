using Microsoft.EntityFrameworkCore;
using AsmtAPI.Models;

namespace AsmtAPI.Data;

public partial class SchooldbContext : DbContext
{

    public DbSet<Student> Student { get; set; } = null!;

    public DbSet<Class> Class { get; set; } = null!;

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
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


