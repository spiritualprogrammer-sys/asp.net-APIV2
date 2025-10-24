using System;
using APIV2.Dtos.Comment;
using APIV2.Models;

namespace APIV2.Interfaces;

public interface ICommentRepository
{   

    Task<List<Comments>> GetAllAsync();
    Task<Comments?> GetByIdAsync(int id);

    Task<Comments> CreateAsync(Comments commentModel);

    Task<Comments?> UpdateAsync(int id, Comments commentModel);

    Task<Comments?> DeleteAsync(int id);
}
