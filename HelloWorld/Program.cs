namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            int päivä;
            string kuukausi, väri, päiväsana;

            Console.Write("Missä kuussa synnyit? ");
            kuukausi = Console.ReadLine();

            Console.Write("Minkä värinen paita on päälläsi? ");
            väri = Console.ReadLine();

            Console.Write("Monentena päivänä synnyit? ");
            päivä = int.Parse(Console.ReadLine());

            if (päivä < 1 || päivä > 31)
            {
                Console.WriteLine("Päivä ei ole oikein, syötä oikea päivä: ");
                päivä = int.Parse(Console.ReadLine());
            }

            if (kuukausi == "Tammikuu" || kuukausi == "Helmikuu" || kuukausi == "Joulukuu")
            {
                kuukausi = "Lumisateen";
            }
            else if (kuukausi == "Maaliskuu" || kuukausi == "Huhtikuu" || kuukausi == "Toukokuu")
            {
                kuukausi = "Aamukasteen";
            }
            else if (kuukausi == "Kesäkuu" || kuukausi == "Heinäkuu" || kuukausi == "Elokuu")
            {
                kuukausi = "Kesäpäivän";
            }
            else if (kuukausi == "Syyskuu" || kuukausi == "Lokakuu" || kuukausi == "Marraskuu")
            {
                kuukausi = "Syystuulen";
            }
            else
            {
                kuukausi = "Kirjoitusvirheen";
            }

            if (päivä > 0 && päivä < 6)
            {
                päiväsana = "Kääpiö";
            }
            else if (päivä > 5 && päivä < 11)
            {
                päiväsana = "Haltija";
            }
            else if (päivä > 10 && päivä < 16)
            {
                päiväsana = "Ewok";
            }
            else if (päivä > 15 && päivä < 21)
            {
                päiväsana = "Stormtrooper";
            }
            else if (päivä > 20 && päivä < 26)
            {
                päiväsana = "Hobitti";
            }
            else if (päivä > 25 && päivä < 32)
            {
                päiväsana = "Lohikäärme";
            }
            else
            {
                päiväsana = "Päivätön";
            }

            Console.WriteLine("\nPelinimesi on " + kuukausi + " " + väri + " " + päiväsana + ".");

        }
    }
}