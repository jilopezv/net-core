using System.Linq.Expressions;
using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class Repository<T>:IRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    protected DbSet<T> dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }
    
    public IEnumerable<T> All()
    {
        return  dbSet.ToList();
    }
    
    public IEnumerable<T> GetAll(List<Expression<Func<T, bool>>>? filters = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filters != null)
        {
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
        }

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties.Split(new Char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }

        return query.ToList();
    }

    public  T GetById(string id)
    {
        return  dbSet.Find(id);
    }
    
    public T GetById(int id)
    {
        return dbSet.Find(id);
    }

    public T Add(T entity)
    { 
        return dbSet.Add(entity).Entity;
    }

    public bool Delete(int id)
    {
        var entity = dbSet.Find(id);
        if (entity != null)
        {
            dbSet.Remove(entity);
            return true;
        }
        return false;
    }
    
    public bool Delete(string id)
    {
        var entity = dbSet.Find(id);
        if (entity != null)
        {
            dbSet.Remove(entity);
            return true;
        }
        return false;
    }
    
    
    
}