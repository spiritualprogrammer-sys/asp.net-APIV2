using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIV2.Models;


[Table("Comments")]
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
