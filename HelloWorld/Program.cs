namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            int luku;

            Console.Write("Anna luku: ");
            luku = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Kertitaulu luvulle " + luku + ":");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(luku + " * " +(i+1) + " = " + (luku * (i+1)));
            }


        }

    }
    }

