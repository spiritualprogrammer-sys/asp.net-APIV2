using System;

namespace APIV2.Dtos.Stock;

public class UpdateStockRequestDto
{
        public string Symbole { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
     
        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; } 
}
