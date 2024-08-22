using System.ComponentModel.DataAnnotations;


public class Autor
{
    [Key] public int Id { get; set; }
    [Required] public string Nombres { get; set; }
    [Required] public string Apellidos { get; set; }

    public ICollection<Libro> libros { get; set; }
}