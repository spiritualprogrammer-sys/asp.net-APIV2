using System;
using APIV2.Dtos.Comment;
using APIV2.Models;

namespace APIV2.Mappers;

public static class CommentMappers
{
 public static CommentDto ToCommentDto(this Comments commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockId = commentModel.StockId,

        };

    }


     public static Comments ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
    {
        return new Comments
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId,

        };

    }

         public static Comments ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
    {
        return new Comments
        {
            Title = commentDto.Title,
            Content = commentDto.Content
        };

    }
}
