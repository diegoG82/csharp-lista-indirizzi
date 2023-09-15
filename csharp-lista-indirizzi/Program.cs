
using csharp_lista_indirizzi;

//CREO LISTA INDIRIZZI
List<Indirizzo> indirizzi = new List<Indirizzo>();

try
{
    string[] linee = File.ReadAllLines("C:\\Users\\diego\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

    for (int i = 1; i < linee.Length; i++)
    {
        string[] campi = linee[i].Split(',');

        if (campi.Length < 6)
        {
            Console.WriteLine($"La riga {i + 1} non contiene abbastanza campi: {linee[i]}");
            continue; // Vai avanti con la prossima riga
        }

        string name = campi[0];
        string surname = campi[1];
        string street = campi[2];
        string city = campi[3];
        string province = campi[4];
        int zip;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(campi[5]))
        {
            Console.WriteLine($"La riga {i + 1} contiene campi obbligatori mancanti: {linee[i]}");
            continue; // Vai avanti con la prossima riga
        }

        if (int.TryParse(campi[5], out zip))
        {
            Console.WriteLine($"Indirizzo di: {name} {surname} è: {street}, {city}, {province}, {zip}");

            Indirizzo nuovoIndirizzo = new Indirizzo(name, surname, street, city, province, zip);

            indirizzi.Add(nuovoIndirizzo);
        }
        else
        {
            Console.WriteLine($"La riga {i + 1} contiene il seguente Zip non valido: {campi[5]}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
