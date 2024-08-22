namespace Data.Repository.IRepository;

public interface IUnitOfWork: IDisposable
{
    ILibroRepository Libros { get; } // we have only get because we don't want to set the repository. setting the repository will be done in the UnitOfWork class
    void Complete(); // this method will save all the changes made to the database
}