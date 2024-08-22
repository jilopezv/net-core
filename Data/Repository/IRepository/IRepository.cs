using System.Linq.Expressions;

namespace Data.Repository.IRepository;

public interface IRepository<T> where T : class // T is a generic type, it means that it can be of any type
{
    IEnumerable<T> All(); // Task is a type that represents an asynchronous operation that can return a value
    
    IEnumerable<T> GetAll(
        List<Expression<Func<T, bool>>>? filters = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = null
    );
    
    T GetById(string id);
    
    T GetById(int id);

    T Add(T entity); 

    bool Delete(int id);

    bool Delete(string id);

}