using System;
using APIV2.Dtos.Stock;
using APIV2.Helpers;
using APIV2.Models;

namespace APIV2.Interfaces;

public interface IStockRepository
{
    Task<List<Stocks>> GetAllAsync(QueryObject queryObject);
    Task<Stocks?> GetByIdAsync(int id);

    Task<Stocks> CreateAsync(Stocks stocks);

    Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

    Task<Stocks?> DeleteAsync(int id);

    Task<bool> StockExists(int id);
}
