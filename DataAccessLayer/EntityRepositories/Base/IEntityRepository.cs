using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityRepositories.Base
{
    /// <summary>
    /// Interface for base entity class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="F"></typeparam>
    public interface IEntityRepository<T,F> where T:class where F:class
    {
        List<T> Get(F filter);
        Task<List<T>> GetAsync(F filter);
        T Create(T source);
        Task<T> CreateAsync(T source);
        T Update(T source);
        Task<T> UpdateAsync(T source);
        T Delete(T source);
        Task<T> DeleteAsync(T source);
    }
}
