using System;
using System.ComponentModel.DataAnnotations;

namespace APIV2.Dtos.Comment;

public class CreateCommentDto
{

    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 charactere")]
    [MaxLength(280, ErrorMessage = "Title cannot be over 280 characteres")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(5, ErrorMessage = "Content must be 5 charactere")]
    [MaxLength(280, ErrorMessage = "Content cannot be over 280 characteres")]
    public string Content { get; set; } = string.Empty; 
    
}
