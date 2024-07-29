using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerBook.Models;

namespace ServerBook.Data
{
    public class BaseContext :  DbContext
    {   
        public BaseContext(DbContextOptions<BaseContext> options): base(options)
        {
            
        }
        
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

    }
}