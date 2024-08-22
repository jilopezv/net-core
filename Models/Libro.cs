using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Libro
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key] 
    public string Isbn { get; set; }
    [Required] 
    public string? Nombre { get; set; }
    public string Genero { get; set; }
    [Required] 
    public DateTime FechaPublicacion { get; set; }
    [Required] 
    public int NumeroPaginas { get; set; }
    [Required] 
    public int Precio { get; set; }
    
    [Required] 
    public int AutorId { get; set; }
    
    public Autor? Autor { get; set; }
}