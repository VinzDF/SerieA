namespace SerieA.Models
{
    public class Campionato
    {
        public int Id { get; set; }
        public string? NomeCampionato { get; set; }
        public ICollection<Squadra> Squadra { get; set; } = new List<Squadra>();
        public string ? Nazione { get; set; }
        public int Anno { get; set; }
    }
}
