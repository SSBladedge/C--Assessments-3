using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AsmtAPI.Models;

public partial class SchooldbContext : DbContext
{
    private readonly IConfiguration configuration;

    public SchooldbContext(DbContextOptions<SchooldbContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionStrings"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
