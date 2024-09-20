namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            Console.WriteLine("Syötä jokin luku: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Syötä ikäsi: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (num1 > (num2 * 2))
            {
                Console.WriteLine("Iso luku");
            }
            else
            {
                Console.WriteLine("Pieni luku");
            }


        }

    }
}