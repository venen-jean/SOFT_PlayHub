using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.application
{
    public class CrudService<T> where T : class
    {
        private readonly DbContext _context;

        public CrudService()
        {
            _context = globalstore.Daten;
        }

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
                throw new CrudServiceException(
                    $"Cannot delete {typeof(T).Name}: it may be referenced by other data", ex);
            }
            catch (Exception ex)
            {
                throw new CrudServiceException($"Error deleting {typeof(T).Name}", ex);
            }
        }

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

    public class CrudServiceException : Exception
    {
        public CrudServiceException(string message) : base(message) { }
        public CrudServiceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}