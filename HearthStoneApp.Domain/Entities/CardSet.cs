﻿namespace HearthStoneApp.Domain.Entities
{
    public class CardSet
    {
        public long CardSetId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Card> Cards { get; set; }
    }
}
