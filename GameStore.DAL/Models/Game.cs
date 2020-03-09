using System;

namespace GameStore.DAL.Models
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
