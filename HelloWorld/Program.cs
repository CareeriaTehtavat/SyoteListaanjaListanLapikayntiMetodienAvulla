namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            // alustetaan tekstityyppiä edustava muuttuja jonka nimi on nimi
            String nimi;
            // tulostetaan konosoliin kysymys käyttäjälle
            Console.WriteLine("Mikä on nimesi?");
            // syötetään muuttujan arvoksi käyttäjän konsoliin kirjoittama syöte
            nimi = Console.ReadLine();
            Console.WriteLine($"Hello {nimi}!");
        }

    }
}
