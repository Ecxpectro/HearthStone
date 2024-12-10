namespace HearthStoneApp.Aplication.Dtos
{
    public class CardDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string? Text { get; set; }
        public string? Flavor { get; set; }
        public string? ImgUrl { get; set; }
        public long? CardSetId { get; set; }
        public long? RarityId { get; set; }
        public long? PlayerClassId { get; set; }
        public long? ArtistId { get; set; }
        public string? Artist { get; set; }
        public string? PlayerClass { get; set; }
        public string? Rarity { get; set; }
        public string? CardSet { get; set; }
    }
}
