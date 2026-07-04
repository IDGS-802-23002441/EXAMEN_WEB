using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;

namespace TiendaAPI.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        return await BuildQuery()
            .OrderBy(product => product.Nombre)
            .ToListAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        return await BuildQuery()
            .FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<List<ProductDto>> SearchByNameAsync(string nombre)
    {
        var searchTerm = nombre.Trim();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAllAsync();
        }

        return await BuildQuery()
            .Where(product => EF.Functions.Like(product.Nombre, $"%{searchTerm}%"))
            .OrderBy(product => product.Nombre)
            .ToListAsync();
    }

    public async Task<List<ProductDto>> GetByCategoryIdAsync(int categoriaId)
    {
        return await BuildQuery()
            .Where(product => product.CategoriaId == categoriaId)
            .OrderBy(product => product.Nombre)
            .ToListAsync();
    }

    private IQueryable<ProductDto> BuildQuery()
    {
        return _context.Products
            .AsNoTracking()
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Nombre = product.Nombre,
                Descripcion = product.Descripcion,
                Precio = product.Precio,
                Imagen = product.Imagen,
                CategoriaId = product.CategoriaId,
                CategoriaNombre = product.Categoria != null ? product.Categoria.Nombre : string.Empty
            });
    }
}