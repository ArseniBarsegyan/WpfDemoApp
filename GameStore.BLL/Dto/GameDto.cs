using System;

namespace GameStore.BLL.Dto
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }        
    }
}
