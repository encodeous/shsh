using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace shortener.Data
{
    public class SHSHConnector : DbContext
    {
        public DbSet<ShortLink> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=shsh.db");
        }
    }

    public class ShortLink
    {
        [Key]
        public string Link { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public string Redirect { get; set; }
    }
}