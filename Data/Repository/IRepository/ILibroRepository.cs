using Data.Repository.IRepository;

namespace Data.Repository;

public interface ILibroRepository : IRepository<Libro>
{
    IEnumerable<Libro> AllDetails();
    Libro Update(Libro entity);

    Libro? GetDetailsById(string isbn);
}