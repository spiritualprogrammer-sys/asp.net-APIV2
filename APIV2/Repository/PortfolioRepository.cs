using System;
using APIV2.Data;
using APIV2.Interfaces;
using APIV2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Repository;

public class PortfolioRepository: IPortfolioRepository
{
    private readonly ApplicationContextDb _context ;
    public PortfolioRepository(ApplicationContextDb applicationContextDb)
    {
        _context = applicationContextDb;
    }

    public async  Task<List<Stocks>> GetUserPortfolio(AppUser user)
    {
        return await  _context.Portfolios.Where(p => p.AppUserId == user.Id)
                .Select(stock => new Stocks
                {
                    Id = stock.StockId,
                    Symbole  = stock.Stock.Symbole,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap,

                }).ToListAsync() ;
    }
}
