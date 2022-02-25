namespace BasicProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BasicProject.Domain;
    using Microsoft.EntityFrameworkCore;

    public class PgContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=30432;Database=blogs;User ID=postgres;Password=password;Integrated Security=true;Pooling=true");
        }

    }
}
