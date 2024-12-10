namespace HearthStoneApp.Domain.Entities
{
    public class Artist
    {
        public long ArtistId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Card> Cards { get; set; }
    }
}
