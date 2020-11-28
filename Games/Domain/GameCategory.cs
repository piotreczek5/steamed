using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Games.Domain
{
    public class GameCategory
    {
        public int GameId { get; set; }
        public int CategoryId { get; set; }
        public int Level { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
