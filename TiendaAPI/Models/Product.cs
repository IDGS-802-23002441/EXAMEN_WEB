namespace TiendaAPI.Models;

public class Product
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public string Imagen { get; set; } = string.Empty;

    public int CategoriaId { get; set; }

    public Category? Categoria { get; set; }
}