using DDD.Application.Interfaces;
using DDD.Domain.Interfaces;
using DDD.Infrastructure.EntityFramework.Contexts;
using DDD.Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDD.Infrastructure.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WeatherForecastDBContext context;
        private IWeatherForecastRepository? weatherForecastRepository;

        public UnitOfWork(WeatherForecastDBContext context)
        {
            this.context = context;
        }

        public IWeatherForecastRepository WeatherForecastRepository
        {
            get
            {
                if(this.weatherForecastRepository == null)
                {
                    this.weatherForecastRepository = new WeatherForecastRepository(context);
                }

                return this.weatherForecastRepository;
            }
        }

        public void Save()
        {
            this.AddAuditInfo();

            this.context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            this.AddAuditInfo();

            await this.context.SaveChangesAsync();
        }

        public bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddAuditInfo()
        {
            List<EntityEntry<IAudit>> audits = this.context.ChangeTracker.Entries<IAudit>().ToList();

            foreach (EntityEntry<IAudit> entity in audits.Where(e => e.State == EntityState.Added).ToList())
            {
                entity.Entity.CreatedAt = DateTime.UtcNow;
            }
            foreach (EntityEntry<IAudit> entity in audits.Where(e => e.State == EntityState.Modified).ToList())
            {
                entity.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
