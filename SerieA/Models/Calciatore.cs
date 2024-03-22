namespace SerieA.Models
{
    public class Calciatore
    {
        public int ID { get; set; }
        public string ? Nome {  get; set; }
        public string ? Cognome { get; set; }
        public int NumeroMaglia { get; set; }
        public Squadra ? Squadra {  get; set; }

        public Calciatore() { }


    }
}
