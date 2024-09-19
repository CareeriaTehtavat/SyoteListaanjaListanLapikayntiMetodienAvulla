namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            Console.Write("Syötä ikäsi: ");
            int ika = int.Parse(Console.ReadLine());

            if (ika < 10)
            {
                Console.WriteLine("    olet lapsi.");
            }
            else if (ika < 18)
            {
                Console.WriteLine(" olet teini.");
            }
            else
            {
                Console.WriteLine("olet aikuinen.   ");
            }
        }

    }
}
