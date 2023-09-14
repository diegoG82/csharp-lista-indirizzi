


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


            if (stringSplits.Length < 3)
            {
                Console.WriteLine($"l'indirizzo {linea} non è leggibile!");
            }
            else
            {

                char[] leadingCharactersToRemove = new char[] { ' ', '-' };

                string name = stringSplits[0].TrimStart(leadingCharactersToRemove);
                string surname = stringSplits[1];
                string street = stringSplits[2];
                string city = stringSplits[3];
                string province = stringSplits[4];
                int zip = int.Parse(stringSplits[5]);

                Console.WriteLine($"indirizzo: {name}, {surname}, {street}, {city}, {province}, {zip}");

                Indirizzo nuovoindirizzo = new Indirizzo(name, surname, street, city, province, zip);

              indirizzi.Add(nuovoindirizzo);

            }
        }
    }

    listaindirizzi.Close();


}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// LEGGO E STAMPO LA LISTA DEI MIEI LIBRI e nel frattempo la scrivo in un file:
try
{

    StreamWriter fileToWrite = File.CreateText("C:\\Users\\diego\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

    for (int i = 0; i < indirizzi.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {indirizzi[i]}");
        fileToWrite.WriteLine($"{i + 1}. {indirizzi[i]}");
    }

    fileToWrite.Close();
}
catch
{
    Console.WriteLine("C'è stata un'eccezione");
}




