namespace csharp_lista_indirizzi


{
    public class Indirizzo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public int Zip { get; set; }

        public Indirizzo(string name, string surname, string street, string city, string province, int zip)
        {
            Name = name;
            Surname = surname;
            Street = street;
            City = city;
            Province = province;
            Zip = zip;
        }

      

    }
}


