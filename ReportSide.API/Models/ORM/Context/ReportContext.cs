using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSide.API.Models.ORM.Context
{
    public class ReportContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-155-226-153.eu-west-1.compute.amazonaws.com;Database=d8mbku21tv8ldl;UID=tfpdrapiihcttv;PWD=0312df20391e879feb8fa79b9e319cced82b558ab8ae7a8fdc52e45998cb20cc;SSL Mode= Require;TrustServerCertificate=True");
        }

        public DbSet<Report> reports { get; set; }

    }
}
