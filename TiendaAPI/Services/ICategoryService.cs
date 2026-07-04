using TiendaAPI.DTOs;

namespace TiendaAPI.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
}