namespace HearthStoneApp.Aplication.Dtos
{
    public class CardDto
    {
        public long CardId { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string? Text { get; set; }
        public string? Flavor { get; set; }
        public string? ImgUrl { get; set; }
    }
}
