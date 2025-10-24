using System;
using APIV2.Dtos.Stock;
using APIV2.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace APIV2.Mappers;

public static class StockMappers
{

    public static StockDto ToStockDto(this Stocks stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbole = stockModel.Symbole,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
        };

    }
    
    public static Stocks ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stocks
        {
            Symbole = stockDto.Symbole,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap,
        };
    }
}
