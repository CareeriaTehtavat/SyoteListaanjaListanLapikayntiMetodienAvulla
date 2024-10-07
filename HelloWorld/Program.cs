namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sana1 = "careeria";

            Console.WriteLine(sana1.Substring(1));
            Console.WriteLine(sana1.Substring(0, 7) + sana1.Substring(8));
            Console.WriteLine(sana1.Substring(0, 1) + sana1.Substring(2));

            Console.WriteLine("Anna sana: ");
            string sana = Console.ReadLine();
            string uusiSana = sana[sana.Length - 1] + sana.Substring(1, sana.Length - 2) + sana[0];
            Console.WriteLine(uusiSana);
            Console.WriteLine("Anna uusi sana: ");
            string sana3 = Console.ReadLine();
            string sana3_edit = sana3[0] + sana3 + sana3[0];
            Console.WriteLine(sana3_edit);
        }
    }
}