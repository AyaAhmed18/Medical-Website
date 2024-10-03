using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Context;
using MedicalWebsite.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalWebsite.Infrastructure
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
    {
        private readonly MedicalContext _medicalContext;
        private readonly DbSet<TEntity> _tEntity;

        public Repository(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
            _tEntity = _medicalContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await _medicalContext.AddAsync(entity)).Entity;
            
        }

        public  Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Task.FromResult( _medicalContext.Remove(entity).Entity); 
            
        }

        public  Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult( _tEntity.Select(e=>e));        }

        public async Task<TEntity> GetByIdAsync(TID id)
        {
            return await _tEntity.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _medicalContext.SaveChangesAsync();
        }

        public  Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult( _medicalContext.Update(entity).Entity);
        }
    }
}
