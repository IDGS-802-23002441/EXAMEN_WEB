using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;

namespace TiendaAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .OrderBy(category => category.Nombre)
            .Select(category => new CategoryDto
            {
                Id = category.Id,
                Nombre = category.Nombre
            })
            .ToListAsync();
    }
}