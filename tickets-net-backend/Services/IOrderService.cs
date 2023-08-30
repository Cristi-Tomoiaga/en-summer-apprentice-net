using Microsoft.AspNetCore.Mvc;
using TicketsNetBackend.Models.Dto;

namespace TicketsNetBackend.Services
{
    public interface IOrderService
    {
        Task<OrdersDto> GetAllAsync();
        Task<OrderGetDto> GetByIdAsync(int id);
        Task<OrderGetDto> PatchAsync(int id, OrderPatchDto orderPatch, int customerId);
        Task DeleteAsync(int id, int customerId);
    }
}
