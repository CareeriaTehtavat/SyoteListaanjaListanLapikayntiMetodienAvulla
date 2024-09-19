using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("5", "3")]
        [InlineData("10", "2")]
        [InlineData("7", "2")]
        [InlineData("8", "4")]
        [Trait("TestGroup", "ArithmeticOperations")]
        public void ArithmeticOperations(string num1, string num2)
        {
            // Arrange
            var input = new StringReader($"{num1}\n{num2}\n"); // Simulate user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Calculate expected values
            int luku1 = Int32.Parse(num1);
            int luku2 = Int32.Parse(num2);
            int summa = luku1 + luku2;
            int erotus = luku1 - luku2;
            int tulo = luku1 * luku2;
            int osamaara = luku1 / luku2;

            // Prepare expected output
            var expectedOutput = new List<string>
    {
        $"Lukujen Summa: {luku1} + {luku2} = {summa}",
        $"Lukujen Erotus: {luku1} - {luku2} = {erotus}",
        $"Lukujen Tulo: {luku1} * {luku2} = {tulo}",
        $"Lukujen Osam‰‰r‰: {luku1} / {luku2} = {osamaara}"
    };

            // Adjust the output indices (skip prompt lines)
            int outputStartIndex = 1; // Adjust based on actual output

            // Assert that each line of output matches the expected arithmetic results
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                Assert.True(LineContainsIgnoreSpaces(result[outputStartIndex + i], expectedOutput[i]),
                    $"Expected: {expectedOutput[i]} but got: {result[outputStartIndex + i]}");
            }
        }


        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace from the line and the expected text
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();
            return normalizedLine.Contains(normalizedExpectedText);
        }


        private int CountWords(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private bool CompareLines(string[] actualLines, string[] expectedLines)
        {
            if (actualLines.Length != expectedLines.Length)
            {
                return false;
            }

            for (int i = 0; i < actualLines.Length; i++)
            {
                if (actualLines[i] != expectedLines[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}