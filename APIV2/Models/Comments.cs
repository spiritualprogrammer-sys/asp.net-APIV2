using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIV2.Models;

public class Comments
{

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty; 
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    // Clé étrangère
    public int StockId { get; set; }

    public Stocks? Stock { get; set; }
}
