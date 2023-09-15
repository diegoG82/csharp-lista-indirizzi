
using csharp_lista_indirizzi;

//CREO LISTA INDIRIZZI
List<Indirizzo> indirizzi = new List<Indirizzo>();

try
{
    StreamReader listaindirizzi = File.OpenText("C:\\Users\\diego\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

    int numerolinea = 0;

    while (!listaindirizzi.EndOfStream)
    {
        string linea = listaindirizzi.ReadLine();
        numerolinea++;

        if (numerolinea > 1)
        {
            string[] stringSplits = linea.Split(',');


            if (stringSplits.Length < 6)
            {
                Console.WriteLine($"l'indirizzo {linea} non è leggibile!");
            }

            else
            {
                string name = stringSplits[0];
                string surname = stringSplits[1];
                string street = stringSplits[2];
                string city = stringSplits[3];
                string province = stringSplits[4];
                int zip = int.Parse(stringSplits[5]);

                Console.WriteLine($"indirizzo di: {name} {surname} e': {street}, {city}, {province}, {zip}");

                Indirizzo nuovoindirizzo = new Indirizzo(name, surname, street, city, province, zip);

                indirizzi.Add(nuovoindirizzo);

            }
        }
    }

    listaindirizzi.Close();


}
catch (Exception)
{
    Console.WriteLine("Ci sono errori!!");
    Console.WriteLine();

}


//CODICE  TEST

try
{
    string[] linea = File.ReadAllLines("C:\\Users\\diego\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");
    for (int i = 1; i < linea.Length; i++)
    {
        string[] fields = linea[i].Split(',');
        if (fields.Length < 6)
        {
            Console.WriteLine($"l'indirizzo {linea[i]} ha degli errori");
            continue;
        }
        else
        {
            string name = fields[0];
            string surname = fields[1];
            string street = fields[2];
            string city = fields[3];
            string province = fields[4];
            int zip;
            if (int.TryParse(fields[5], out zip))
            {
                Console.WriteLine($"indirizzo di: {name} {surname} e': {street}, {city}, {province}, {zip}");

                Indirizzo nuovoindirizzo = new Indirizzo(name, surname, street, city, province, zip);

                indirizzi.Add(nuovoindirizzo);
            }
            else
            {
                Console.WriteLine($"l'indirizzo {linea[i]} ha degli errori");
                Console.WriteLine();
            }
        }
    }


}
catch (Exception e)
{
    Console.WriteLine(e.Message);
  


}





///SOLUZIONE DECENTE


//CREO LISTA INDIRIZZI
List<Indirizzo> indirizziok = new List<Indirizzo>();

try
{
    string[] linee = File.ReadAllLines("C:\\Users\\diego\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

    for (int i = 1; i < linee.Length; i++)
    {
        string[] campi = linee[i].Split(',');

        if (campi.Length < 6)
        {
            Console.WriteLine($"La riga {i + 1} non è formattata correttamente: {linee[i]}");
            continue; // Vai avanti con la prossima riga
        }

        string name = campi[0];
        string surname = campi[1];
        string street = campi[2];
        string city = campi[3];
        string province = campi[4];
        int zip;

        if (int.TryParse(campi[5], out zip))
        {
            Console.WriteLine($"Indirizzo di: {name} {surname} è: {street}, {city}, {province}, {zip}");

            Indirizzo nuovoIndirizzo = new Indirizzo(name, surname, street, city, province, zip);

            indirizziok.Add(nuovoIndirizzo);
        }
        else
        {
            Console.WriteLine($"Il campo ZIP nella riga {i + 1} non è un numero valido: {campi[5]}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

