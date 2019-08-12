using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LOC_WebApi.Models
{
    public class Teams
    {
        public Guid Guid { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string ShortName { get; set; }
        public int Coins { get; set; }
        public string Participants { get; set; }
        public string Achievements { get; set; }
        public string test { get; set;}
        public Teams()
        {
            Guid = Guid.NewGuid();
        }
    }

    public class TeamsDBContext : DbContext
    {
        public TeamsDBContext() : base("MainBase") { }
        public DbSet<Teams> Teams { get; set; }
    }
}