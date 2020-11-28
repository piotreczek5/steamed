using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steamed.Comments.Infrastructure
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    
}
