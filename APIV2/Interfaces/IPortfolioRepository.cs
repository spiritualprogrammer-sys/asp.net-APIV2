using System;
using APIV2.Models;

namespace APIV2.Interfaces;

public interface IPortfolioRepository
{

    Task<List<Stocks>> GetUserPortfolio(AppUser user);

}
