using System;
using APIV2.Data;
using APIV2.Dtos.Stock;
using APIV2.Helpers;
using APIV2.Interfaces;
using APIV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Repository;

public class StockRepository : IStockRepository
{

    private readonly ApplicationContextDb _context;


    public StockRepository(ApplicationContextDb context)
    {
      
        _context=context;
    }

    public async Task<Stocks> CreateAsync(Stocks stockModel)
    {
        await  _context.AddAsync(stockModel);
        await  _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stocks?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null)
        {
            return null;
        }
        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;

    }

    public  async Task<List<Stocks>> GetAllAsync(QueryObject queryObject)
    {
        var stocks =  _context.Stocks.Include(c => c.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
        {
            stocks = stocks.Where(x => x.CompanyName.Contains(queryObject.CompanyName));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
        {
            stocks = stocks.Where(x => x.Symbole.Contains(queryObject.Symbol));
        }

       return await stocks.ToListAsync();
    }

    public async Task<Stocks?> GetByIdAsync(int id)
    {
        return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> StockExists(int id)
    {
        return _context.Stocks.AnyAsync(s => s.Id == id);
    }

    public async  Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
    {
        var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        if (existingStock == null)
        {
            return null;
        }

        existingStock.CompanyName = updateStockRequestDto.CompanyName;
        existingStock.Symbole = updateStockRequestDto.Symbole;
        existingStock.Purchase = updateStockRequestDto.Purchase;
        existingStock.LastDiv = updateStockRequestDto.LastDiv;
        existingStock.Industry = updateStockRequestDto.Industry;
        existingStock.MarketCap = updateStockRequestDto.MarketCap;

        await _context.SaveChangesAsync();
        return existingStock;

    }
}
