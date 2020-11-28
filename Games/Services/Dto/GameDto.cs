using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Services.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<GameCategoryDto> GameCategories { get; set; }
    }
}
