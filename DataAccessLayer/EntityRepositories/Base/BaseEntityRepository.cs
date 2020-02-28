using AddressBook.DataAccessLayer.DAL;
using DataAccessLayer.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityRepositories.Base
{
    /// <summary>
    /// Base class for entity classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="F"></typeparam>
    public class BaseEntityRepository<T,F> : IEntityRepository<T, F> where T : class where F : FilterBase<T>,new()
    {
        #region Data Fields
        protected AddressBookDbEntities Db;
        #endregion
        #region Ctor
        public BaseEntityRepository(AddressBookDbEntities context)
        {
            this.Db = context ?? throw new Exception("Data context not initialized");
        }
        #endregion
        #region Public Methods
        public List<T> Get(F filter)
        {
            if (filter==null)
            {
                filter = new F();
            }
            IQueryable<T> query = this.Db.Set<T>();
            return filter.Filter(query).ToList();
        }
        public async Task<List<T>> GetAsync(F filter)
        {
            if (filter==null)
            {
                filter = new F();
            }
            IQueryable<T> query = this.Db.Set<T>();
            return await filter.Filter(query).ToListAsync();
        }
        public T Create(T source)
        {
            this.Db.Entry<T>(source).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.Db.SaveChanges();
            return source;
        }
        public async Task<T> CreateAsync(T source)
        {
            this.Db.Entry<T>(source).State = EntityState.Added;
            await this.Db.SaveChangesAsync();
            return source;
        }
        public T Update(T source)
        {
            this.Db.Entry<T>(source).CurrentValues.SetValues(source);
            this.Db.SaveChanges();
            return source;
        }
        public async Task<T> UpdateAsync(T source)
        {
            this.Db.Entry<T>(source).CurrentValues.SetValues(source);
            await this.Db.SaveChangesAsync();
            return source;


        }
        public T Delete(T source)
        {
            this.Db.Entry(source).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this.Db.SaveChanges();
            return source;
        }
        public async Task<T> DeleteAsync(T source)
        {
            this.Db.Entry(source).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await this.Db.SaveChangesAsync();
            return source;
        }
        #endregion
    }
}
