using Net_Core_API_Store.Models;

namespace Net_Core_API_Store.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(Producto producto);
        Task<bool> ExistsAsync(int id);
    }
}
