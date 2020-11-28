using MongoDB.Driver;
using Steamed.Comments.Domain;
using Steamed.Comments.Services.Dto;
using Steamed.Core.Generic;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Services
{
    public class CommentService : BaseDbMongoCollectionCrudService<Comment, CommentDto>, ICommentService
    {

        public CommentService(IMongoCollection<Comment> collection, IMapper mapper) : base(collection, mapper)
        {
        }
    }
}
