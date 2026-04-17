using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.application
{
    /// <summary>
    /// Enhanced generic CRUD service with error handling, validation, and tracking
    /// </summary>
    public class CrudService<T> where T : class
    {
        private readonly DbContext _context;

        public CrudService()
        {
            _context = globalstore.Daten;
        }

        /// <summary>
        /// Load all entities into a binding source for data binding
        /// </summary>
        public BindingSource Load(BindingSource source)
        {
            try
            {
                var entities = _context.Set<T>().ToList();
                source.DataSource = entities;
                return source;
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error loading {typeof(T).Name} entities", ex);
            }
        }

        /// <summary>
        /// Create a new entity with validation
        /// </summary>
        public T Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException ex)
            {
                throw new CrudServiceException($"Validation error creating {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error creating {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Update an existing entity (tracked by EF)
        /// </summary>
        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException ex)
            {
                throw new CrudServiceException($"Validation error updating {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error updating {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Often caused by foreign key constraints
                throw new CrudServiceException(
                    $"Cannot delete {typeof(T).Name}: it may be referenced by other data", ex);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error deleting {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Save changes to the context (for bulk operations)
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new CrudServiceException($"Validation error saving {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error saving {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Get entity by primary key (assumes 'id' property)
        /// </summary>
        public T GetById(object id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error retrieving {typeof(T).Name} by ID", ex);
            }
        }

        /// <summary>
        /// Get all entities with optional filtering
        /// </summary>
        public List<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error retrieving all {typeof(T).Name} entities", ex);
            }
        }

        /// <summary>
        /// Check if an entity exists (useful before deleting)
        /// </summary>
        public bool Exists(T entity)
        {
            try
            {
                return _context.Set<T>().Contains(entity);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error checking if {typeof(T).Name} exists", ex);
            }
        }

        /// <summary>
        /// Format exception messages for display
        /// </summary>
        public static string GetFullExceptionMessage(Exception ex)
        {
            var messages = new List<string>();
            while (ex != null)
            {
                messages.Add(ex.Message);
                ex = ex.InnerException;
            }
            return string.Join(Environment.NewLine, messages);
        }
    }

    /// <summary>
    /// Custom exception for CRUD operations
    /// </summary>
    public class CrudServiceException : Exception
    {
        public CrudServiceException(string message) : base(message) { }
        public CrudServiceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}