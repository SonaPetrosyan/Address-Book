using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataAccessLayer.DAL
{
    /// <summary>
    /// Db entities
    /// </summary>
    public class AddressBookDbEntities : DbContext
    {
        public AddressBookDbEntities(DbContextOptions<AddressBookDbEntities> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Contact>().ToTable("Contact");
        }
    }
}
