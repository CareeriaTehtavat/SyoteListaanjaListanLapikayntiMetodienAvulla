namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            // alustetaan tekstityyppiä edustava muuttuja jonka nimi on nimi
            string nimi, kaupunki, ika;

            // tulostetaan konosoliin kysymys käyttäjälle
            Console.WriteLine("Mikä on nimesi?");
            nimi = Console.ReadLine(); // syötetään muuttujan arvoksi käyttäjän konsoliin kirjoittama syöte

            Console.WriteLine("Mikä on ikä?");
            ika = Console.ReadLine(); // syötetään muuttujan arvoksi käyttäjän konsoliin kirjoittama syöte

            Console.WriteLine("Mikä on kaupunkisi?");
            kaupunki = Console.ReadLine(); // syötetään muuttujan arvoksi käyttäjän konsoliin kirjoittama syöte

            Console.WriteLine($"Nimesi on {nimi}, ja olet {ika} vuotta vanha. Kotikaupunki: {kaupunki}");

        }

    }
}

