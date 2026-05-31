using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<ApiClient> ApiClients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApiClient>().HasData(
                new ApiClient
                {
                    Id = 1,
                    ClientName = "TestClient1",
                    ApiKey = "test-key-1"
                },
                new ApiClient
                {
                    Id = 2,
                    ClientName = "TestClient2",
                    ApiKey = "test-key-2"
                }
            );
        }
    }
}
