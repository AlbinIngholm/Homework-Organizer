using LekseOrganisering;
using System.Text.Json;

List<Lekse> lekser = new();
bool run = true;

while (run)
{
    try
    {
        loadJson();
        Console.WriteLine("Velkommen til lekseorganisering. Velg hvilken handling du vil utføre.");
        Console.WriteLine("1: Legg til ny lekse");
        Console.WriteLine("2: Marker lekse som fullført");
        Console.WriteLine("3: Vis alle lekser");
        Console.WriteLine("4: Avslutt programmet");

        int valg = Convert.ToInt32(Console.ReadLine());
        switch (valg)
        {
            case 1:
                NyLekse();
                break;
            case 2:
                SnuStatus();
                break;
            case 3:
                SkrivUtLekser();
                break;
            case 4:
                lagreJson();
                run = false;
                break;
            default:
                Console.WriteLine("Error. Prøv igjen");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Feil. Vennligst skriv inn et tall.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"En feil oppstod: {ex.Message}");
    }
}

void SnuStatus()
{
    try
    {
        // vis lekser til brukeren
        SkrivUtLekser();

        Console.WriteLine("Hvilken lekse vil du endre status på? (angi nummer)");
        int nummer = Convert.ToInt32(Console.ReadLine());

        // sjekker at nummeret ikke er 0, og ikke høyere enn antall lekser
        if (nummer > 0 && nummer <= lekser.Count)
        {
            // snur status på leksen
            lekser[nummer - 1].SnuStatus();
            Console.WriteLine($"Statusen for lekse {lekser[nummer - 1].Tittel} er nå '{StatusSjekk(lekser[nummer - 1].Status)}'.");
        }
        else
        {
            Console.WriteLine("Ugyldig valg, prøv igjen.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Ugyldig inndata. Vennligst skriv inn et tall.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"En feil oppstod: {ex.Message}");
    }
}

void NyLekse() // funksjon for å legge til ny lekse
{
    Console.WriteLine("Skriv inn tittel på lekse: ");
    string? tittel = Console.ReadLine();
    Console.WriteLine("Skriv inn en beskrivelse på leksen: ");
    string? beskrivelse = Console.ReadLine();

    try
    {
        Lekse nyLekse = new Lekse(tittel, beskrivelse);
        lekser.Add(nyLekse);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Feil ved opprettelse av ny lekse: {ex.Message}");
    }
}

void SkrivUtLekser() // funksjon for å skrive ut leksene
{
    if (lekser.Count == 0)
    {
        Console.WriteLine("Ingen lekser tilgjengelig.");
    }

    for (int i = 0; i < lekser.Count; i++)
    {
        Console.WriteLine($"{i + 1}: {lekser[i].Tittel}\n" +
                          $"Beskrivelse: {lekser[i].Beskrivelse}\n" +
                          $"Status: {StatusSjekk(lekser[i].Status)}");
    }
}

void lagreJson()
{
    try
    {
        string json = JsonSerializer.Serialize(lekser);
        File.WriteAllText("lekser.json", json);
        Console.WriteLine("Lagret til lekser.json");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Feil ved lagring av JSON: {ex.Message}");
    }
}

void loadJson()
{
    try
    {
        if (File.Exists("lekser.json"))
        {
            string json = File.ReadAllText("lekser.json");
            lekser = JsonSerializer.Deserialize<List<Lekse>>(json) ?? new List<Lekse>();
            Console.WriteLine("Lastet inn fra lekser.json");
        }
    }
    catch (JsonException)
    {
        Console.WriteLine("Feil ved lesing av JSON.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Feil under innlasting av JSON: {ex.Message}");
    }
}

string StatusSjekk(bool status) // funksjon for å sjekke status på leksen
{
    return status ? "Fullført" : "Ikke fullført";
}
