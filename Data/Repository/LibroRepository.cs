using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class LibroRepository : Repository<Libro>, ILibroRepository
{
    public LibroRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<Libro> AllDetails()
    {
        return _context.Libros.Include(libro => libro.Autor).ToList();
    }

    public Libro Update(Libro libro)
    {
        var libroAActualizar = _context.Libros.FirstOrDefault(l => l.Isbn == libro.Isbn);
        libroAActualizar.Nombre = libro.Nombre;
        libroAActualizar.Genero = libro.Genero;
        libroAActualizar.Precio = libro.Precio;
        libroAActualizar.NumeroPaginas = libro.NumeroPaginas;
        libroAActualizar.FechaPublicacion = libro.FechaPublicacion;
        libroAActualizar.AutorId = libro.AutorId;
        _context.SaveChanges();
        return libroAActualizar;
    }

    public Libro GetDetailsById(string isbn)
    {
        return _context.Libros.Include(libro => libro.Autor)
            .First(l => l.Isbn == isbn);
    }
}