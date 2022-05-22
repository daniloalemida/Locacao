using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locacao.Domain.Interfaces;
using Locacao.Domain.Entities;
using Locacao.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.Repositorios
{
    public class EntityRepositorio<T> : IEntityRepositorio<T> where T : Entity
    {
        protected readonly EntityContext _context;
        
        public EntityRepositorio(EntityContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0 ? true : false;
        }

        public async Task<T> CreateAndReturn(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            var result = await _context.SaveChangesAsync();

            return result != 0 ? true : false;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<List<T>> GetAll()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0 ? true : false;
        }
    }
}