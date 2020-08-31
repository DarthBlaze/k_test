
using InterviewTest.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adds an entity list
        /// </summary>
        /// <param name="entities">List of entity to be added</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Gets the list of entities using the predicate
        /// </summary>
        /// <param name="predicate">Predicate for the search</param>
        /// <returns>Returns a list of entity.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Gets an entity using the predicate
        /// </summary>
        /// <param name="predicate">Predicate for the search</param>
        /// <returns>Returns the entity</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Gets an entity using the predicate
        /// </summary>
        /// <param name="predicate">Predicate for the search</param>
        /// <returns>Returns the entity</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Gets an entity using an identifier key
        /// </summary>
        /// <param name="id">Identifier key</param>
        /// <returns>Returns the entity</returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Gets a list of all entities
        /// </summary>
        /// <returns>Returs a list of all entities</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Remove a list of entities
        /// </summary>
        /// <param name="entities">List of entities to be removed</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }


        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }


        /// <summary>
        /// Updates a list of entities
        /// </summary>
        /// <param name="entities">List of entities to be updated</param>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
