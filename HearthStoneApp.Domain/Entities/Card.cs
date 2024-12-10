namespace HearthStoneApp.Domain.Entities
{
    public class Card
    {
        public long CardId { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }
        public int Cost { get; set; }

        public int Attack { get; set; }
        public int Health { get; set; }

        public string? Text { get; set; }
        public string? Flavor { get; set; }
        public string? ImgUrl { get; set; }

        public long? CardSetId { get; set; } 
        public CardSet? CardSet { get; set; }
        public long? RarityId { get; set; }
        public Rarity? Rarity { get; set; }

        public long? PlayerClassId { get; set; }
        public PlayerClass? PlayerClass { get; set; }

        public long? ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
