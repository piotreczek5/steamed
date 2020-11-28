using Core.Generics;
using Steamed.Comments.Services.Dto;

namespace Steamed.Comments.Services
{
    public interface ICommentService : IBaseCrudService<CommentDto>
    {
    }
}