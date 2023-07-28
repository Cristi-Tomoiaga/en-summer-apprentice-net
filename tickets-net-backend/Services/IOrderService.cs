using Microsoft.AspNetCore.Mvc;
using tickets_net_backend.Models.Dto;

namespace tickets_net_backend.Services
{
    public interface IOrderService
    {
        Task<List<OrderGetDto>> GetAllAsync();
        Task<OrderGetDto> GetByIdAsync(int id);
        Task<OrderGetDto> PatchAsync(int id, OrderPatchDto orderPatch);
        Task DeleteAsync(int id);
    }
}
