using Microsoft.AspNetCore.Mvc;
using Steamed.Comments.Services;
using Steamed.Comments.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steamed.Comments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentsService;

        public CommentsController(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
        {
            return Ok(await _commentsService.GetAll());
        }

        [HttpPost("Add")]
        public async Task<ActionResult<CommentDto>> Add([FromBody] CommentDto comment)
        {
            comment.Id = null;
            var addedComment = await _commentsService.Add(comment);
            return Created(addedComment.Id.ToString(), addedComment);
        }
    }
}
