namespace SerieA.Models
{
    public class Squadra
    {
        public int Id { get; set; }
        public string ? Nome { get; set; }
        public DateTime Anno { get; set; }
        public Campionato ? Campionato { get; set; }
        public ICollection<Calciatore> ? Calciatori { get; set; }

        public Squadra() {}

    }
}
