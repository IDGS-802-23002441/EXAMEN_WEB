using TiendaAPI.DTOs;

namespace TiendaAPI.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<List<ProductDto>> SearchByNameAsync(string nombre);

    Task<List<ProductDto>> GetByCategoryIdAsync(int categoriaId);
}