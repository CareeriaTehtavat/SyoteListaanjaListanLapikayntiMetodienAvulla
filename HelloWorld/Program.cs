namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            int luku1, luku2;

            Console.Write("Anna eka luku: ");
            luku1 = int.Parse(Console.ReadLine());
            Console.Write("Anna toka luku: ");
            luku2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nSyöttämäsi luvut: " + luku2 + " ja " + luku1);

        }

    }
}