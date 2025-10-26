using System;

namespace APIV2.Models;

public class Portfolio
{


public int AppUserId { get; set; }
public int PortfolioId { get; set;}
public int StockId { get; set;} 

public AppUser appUser{ get; set; } 
public Stocks stock{ get; set; }
}
