using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH_PETS.Models;
using Microsoft.EntityFrameworkCore;

namespace LH_PETS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<ClienteModel> Cliente {get; set;}

        public DbSet<ForncedorModel> Fornecedor {get; set;}
    }
}