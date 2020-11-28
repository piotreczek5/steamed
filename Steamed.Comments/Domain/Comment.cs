using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Domain
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CommentDate { get; set; }
    }
}
