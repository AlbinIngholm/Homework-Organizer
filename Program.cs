using LekseOrganisering;

List<Lekse> lekser = new();
bool run = true;

while (run)
{
    Console.WriteLine("Velkommen til lekseorganisering. Velg hvilken handling du vil utføre.");
    Console.WriteLine("1: Legg til ny lekse");
    Console.WriteLine("2: Marker lekse som fullført");
    Console.WriteLine("3: Vis alle lekser ");
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
            run = false;
            break;
        default:
            Console.WriteLine("Error. Prøv igjen");
            break;
    }
}

void SnuStatus()
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

void NyLekse() // funksjon for å legge til ny lekse
{
    Console.WriteLine("Skriv inn tittel på lekse: ");
    string? tittel = Console.ReadLine();
    Console.WriteLine("Skriv inn en beskrivelse på leksen: ");
    string? beskrivelse = Console.ReadLine();

    Lekse nyLekse = new Lekse(tittel, beskrivelse);
    lekser.Add(nyLekse);
}

void SkrivUtLekser() // funksjon for å skrive ut leksene
{
    for(int i = 0; i < lekser.Count; i++)
    {
        Console.WriteLine($"{i+1}: {lekser[i].Tittel}\n" +
            $"Beskrivelse: {lekser[i].Beskrivelse}\n" +
            $"Status: {StatusSjekk(lekser[i].Status)}");

    }
}

string StatusSjekk(bool status) // funksjon for å sjekke status på leksen, tar inn en bool som parameter og returnerer en string
{
    if (status)
    {
        return "Fullført";
    } else
    {
        return "Ikke fullført";
    }
}

