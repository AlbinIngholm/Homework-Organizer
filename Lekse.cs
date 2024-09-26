namespace LekseOrganisering
{
    public class Lekse // oppretter en klasse
    {

        public string Tittel { get; set; } // setter attributter
        public string Beskrivelse { get; set; }
        public bool Status { get; set; }

        public Lekse(string tittel, string beskrivelse) // konstruktør for lekseobjekter
        {
            Tittel = tittel;
            Beskrivelse = beskrivelse;
            Status = false;
        }
        public void SnuStatus()
        {
            Status = !Status; // snur status fra false til true, eller omvendt
        }

    }
}
