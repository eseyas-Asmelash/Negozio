using Microsoft.EntityFrameworkCore;
using Negozio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negozio.DataAccess.Sql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }
        public DbSet<Prodotti> Products { get; set; }
        public DbSet<CategoriaProdotti> ProductCategories { get; set; }
    }
}
