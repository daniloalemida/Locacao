using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locacao.Domain.Entities;

namespace Locacao.Domain.Interfaces
{
    public interface IEntityRepositorio<T> : IDisposable where T : Entity
    {
        Task<bool> Create(T entity);
        Task<T> CreateAndReturn(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        
    }
}