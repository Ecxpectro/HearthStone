namespace HearthStoneApp.Domain.Entities
{
    public class Rarity
    {
        public long RarityId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Card> Cards { get; set; }
    }
}
