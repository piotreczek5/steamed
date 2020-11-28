using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Services.Dto
{
    public class GameCategoryDto
    {
        public int GameId { get; set; }
        public int CategoryId { get; set; }
        public string GameTitle { get; set; }
        public string CategoryName { get; set; }
        public int Level { get; set; }
    }
}
