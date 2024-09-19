namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            int luku;

            Console.Write("Syötä valitsemasi luku: ");
            luku = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Antamasi luvun (" + luku + ") kertotaulu:");
            Console.WriteLine(luku + " *     1 " + " = " + (luku * 1));
            Console.WriteLine(luku + " * 2 " + " = " + (luku * 2));
            Console.WriteLine(luku + " * 3 " + " = " + (luku * 3));
            Console.WriteLine(luku + " *    4 " + " = " + (luku * 4));
            Console.WriteLine(luku + " * 5 " + " = " + (luku * 5));
            Console.WriteLine(luku + " * 6 " + " = " + (luku * 6));
            Console.WriteLine(luku + " * 7 " + " = " + (luku * 7));
            Console.WriteLine(luku + " *    8 " + " = " + (luku * 8));
            Console.WriteLine(luku + " *    9 " + " = " + (luku * 9));
            Console.WriteLine(luku + "     * 10 " + " = " + (luku * 10));

        }

    }
    }

