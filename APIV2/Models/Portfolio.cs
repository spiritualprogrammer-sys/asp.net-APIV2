using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIV2.Models;


[Table("Portfolios")]
public class Portfolio
{


public string AppUserId { get; set; }
public int StockId { get; set;} 

public AppUser AppUser{ get; set; } 
public Stocks Stock{ get; set; }
}
