using TicketsNetBackend.Models.Dto;

namespace TicketsNetBackend.Services
{
    public interface IOrderService
    {
        Task<OrdersDto> GetAllAsync();
        Task<OrderGetDto> GetByIdAsync(int id);
        Task<OrderGetDto> PatchAsync(int id, int customerId, OrderPatchDto orderPatch);
        Task DeleteAsync(int id, int customerId);
    }
}
