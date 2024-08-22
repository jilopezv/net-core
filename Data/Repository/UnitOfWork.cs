using Data.Repository.IRepository;

namespace Data.Repository;

public class UnitOfWork:IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public ILibroRepository Libros { get; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Libros = new LibroRepository(db);
    }
    
    public void Complete()
    {
         _db.SaveChanges();
    }
    
    public void Dispose()
    {
        _db.Dispose();
    }
}