using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Services.Dto
{
    public class CommentDto
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
