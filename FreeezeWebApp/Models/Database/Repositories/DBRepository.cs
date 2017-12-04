using System.Collections.Generic;

namespace FreeezeWebApp.Models.Database.Repositories
{
    public abstract class DBRepository<T>
    {
        public DBRepository(DatabaseContext databaseContext)
        {
            this._Context = databaseContext;
        }
        protected DatabaseContext _Context { get; set; }

        internal virtual void SaveChanges()
        {
            this._Context.SaveChanges();
        }

        internal abstract T Find(object id);
        internal abstract List<T> FindAll();
        public abstract void Add(T item, bool saveChanges);
        internal abstract void Remove(T item, bool saveChanges);
        internal abstract void Update(T item, bool saveChanges);
    }
}