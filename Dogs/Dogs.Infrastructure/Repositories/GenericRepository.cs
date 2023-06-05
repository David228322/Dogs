using System.Diagnostics;
using System.Linq.Expressions;
using Dogs.Application.Contracts.Persistence;
using Dogs.Application.Models.Filters;
using Dogs.Domain.Common;
using Dogs.Infrastructure.Extensions;
using Dogs.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Infrastructure.Repositories;

/// <inheritdoc />
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DogContext _dbContext;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dogContext">Database context.</param>
        protected GenericRepository(DogContext dogContext)
        {
            _dbContext = dogContext;
            _dbSet = _dbContext.Set<T>();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetFilteredAsync(PaginationFilter paginationFilter, SortFilter sortFilter)
        {
            var query = _dbSet.AsQueryable();

            if (sortFilter.Attribute is not null)
            {
                var name = sortFilter.Attribute.FirstCharToUpper();
                query = sortFilter.Order == SortingOrder.Desc
                    ? query.OrderBy(e => EF.Property<Activity>(e, name))
                    : query.OrderByDescending(e => EF.Property<Activity>(e, name));
            }
            else
            {
                query = query.OrderByDescending(e => e.DateUpdated);
            }

            var data = await query
                .Skip(paginationFilter.PageNumber)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
            
            return data;
        }

        /// <inheritdoc />
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        /// <inheritdoc />
        public async Task<int> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        /// <inheritdoc />
        public async Task<bool> ExistAsync(
            Expression<Func<T, bool>> predicate = null,
            CancellationToken cancellationToken = default)
        {
            if (predicate is not null)
            {
                return await _dbSet.AnyAsync(predicate, cancellationToken);
            }
        
            return await _dbSet.AnyAsync(cancellationToken);
        }
    }