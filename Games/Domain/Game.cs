using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GameCategory> GameCategories { get; set; } = new HashSet<GameCategory>();
    }
}
