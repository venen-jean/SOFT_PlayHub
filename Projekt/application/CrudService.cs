using System.Linq;
using System.Windows.Forms;

namespace Projekt.application
{
    public class CrudService<T> where T : class
    {
        public BindingSource Load(BindingSource source)
        {
            source.DataSource = globalstore.Daten.Set<T>().ToList();
            return source;
        }

        public void Create(T entity)
        {
            globalstore.Daten.Set<T>().Add(entity);
            globalstore.Daten.SaveChanges();
        }

        public void Delete(T entity)
        {
            globalstore.Daten.Set<T>().Remove(entity);
            globalstore.Daten.SaveChanges();
        }

        public void Save()
        {
            globalstore.Daten.SaveChanges();
        }
    }
}
