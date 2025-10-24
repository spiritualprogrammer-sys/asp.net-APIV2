using System;
using APIV2.Dtos.Comment;
using APIV2.Models;

namespace APIV2.Dtos.Stock;

public class StockDto
{
        public int Id { get; set; }

        public string Symbole { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
       
        public decimal Purchase { get; set; }
  
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; } 

         // Ici le type doit être CommentDto
    public List<CommentDto>? Comments { get; set; }
    
}
