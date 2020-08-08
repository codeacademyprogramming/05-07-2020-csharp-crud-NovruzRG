using Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Crud.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            :base("name=Default")
        {

        }
        public DbSet<Product> product { get; set; }
    }
}