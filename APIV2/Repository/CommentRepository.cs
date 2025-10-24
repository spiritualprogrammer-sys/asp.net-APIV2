using System;
using APIV2.Data;
using APIV2.Dtos.Comment;
using APIV2.Interfaces;
using APIV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Repository;

public class CommentRepository : ICommentRepository
{

    private readonly ApplicationContextDb _context;
    public CommentRepository(ApplicationContextDb contextDb)
    {
        _context = contextDb;
    }

    public async Task<Comments> CreateAsync(Comments commentModel)
    {
       await _context.Comments.AddAsync(commentModel);
       await _context.SaveChangesAsync();
       return commentModel;
    }

    public async Task<Comments?> DeleteAsync(int id)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (commentModel == null)
        {
            return null;
        }
        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;

    }

    public async  Task<List<Comments>> GetAllAsync()
    {
        return  await _context.Comments.ToListAsync ();
    }

    public async Task<Comments?> GetByIdAsync(int id)
    {
       var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return null;
        }
        return comment;
    }

    public async Task<Comments?> UpdateAsync(int id, Comments commentModel)
    {
        var existingComment = await _context.Comments.FindAsync(id) ;
        if (existingComment == null)
        {
            return null ;
        }

        existingComment.Title = commentModel.Title;
        existingComment.Content = commentModel.Content; 

        await _context.SaveChangesAsync();

        return existingComment;
    }
}
