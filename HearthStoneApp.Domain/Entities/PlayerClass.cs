﻿namespace HearthStoneApp.Domain.Entities
{
    public class PlayerClass
    {
        public long PlayerClassId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Card> Cards { get; set; }
    }
}
