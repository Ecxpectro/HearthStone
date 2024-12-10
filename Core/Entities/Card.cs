namespace Core.Entities
{
    public class Card
    {
        public long CardId { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;
        public int Cost { get; set; }

        public int Attack { get; set; }
        public int Health { get; set; }

        public string Text { get; set; } = null!;
        public string Flavor { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
    }
}
