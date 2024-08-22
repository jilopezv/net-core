using System.ComponentModel.DataAnnotations;

public class LibroDto
{
    [Required] 
    public string Isbn { get; set; }
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public int NumeroPaginas { get; set; }
    public int Precio { get; set; }
    public int AutorId { get; set; }
}
