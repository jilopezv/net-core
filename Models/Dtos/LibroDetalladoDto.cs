using System.ComponentModel.DataAnnotations;

public class LibroDetalladoDto
{
    [Required] public string Isbn { get; set; }
    [Required] public string Nombre { get; set; }
    [Required] public string Genero { get; set; }
    [Required] public DateTime FechaPublicacion { get; set; }
    [Required] public int NumeroPaginas { get; set; }
    [Required] public int Precio { get; set; }
    public int AutorId { get; set; }
    public string NombresAutor { get; set; }
    public string ApellidosAutor { get; set; }
}