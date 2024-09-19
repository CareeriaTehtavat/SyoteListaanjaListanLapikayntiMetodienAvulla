using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {


        [Theory]
        [InlineData("Ossi", "22", "Helsinki", "Nimesi on Ossi, ja olet 22 vuotta vanha. Kotikaupunki: Helsinki")]
        [InlineData("Anna", "30", "Tampere", "Nimesi on Anna, ja olet 30 vuotta vanha. Kotikaupunki: Tampere")]
        [InlineData("John", "45", "New York", "Nimesi on John, ja olet 45 vuotta vanha. Kotikaupunki: New York")]
        [InlineData("Maria", "29", "Espoo", "Nimesi on Maria, ja olet 29 vuotta vanha. Kotikaupunki: Espoo")]
        [InlineData("Kalle", "18", "Turku", "Nimesi on Kalle, ja olet 18 vuotta vanha. Kotikaupunki: Turku")]
        [InlineData("Liisa", "35", "Oulu", "Nimesi on Liisa, ja olet 35 vuotta vanha. Kotikaupunki: Oulu")]
        [InlineData("Pedro", "27", "Madrid", "Nimesi on Pedro, ja olet 27 vuotta vanha. Kotikaupunki: Madrid")]
        [InlineData("Sophie", "19", "Paris", "Nimesi on Sophie, ja olet 19 vuotta vanha. Kotikaupunki: Paris")]
        [InlineData("Mikko", "50", "Jyväskylä", "Nimesi on Mikko, ja olet 50 vuotta vanha. Kotikaupunki: Jyväskylä")]
        [InlineData("Emma", "25", "Berlin", "Nimesi on Emma, ja olet 25 vuotta vanha. Kotikaupunki: Berlin")]
        [Trait("TestGroup", "HelloNimi3")]
        public void HelloNimi3(string inputName, string age, string city, string expectedOutput)
        {

            // Arrange
            var input = new StringReader($"{inputName}\n{age}\n{city}\n"); // Simulate all user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert
            Assert.False(string.IsNullOrEmpty(result[0]), "The first line should not be null or empty.");
            Assert.True(LineContainsIgnoreSpaces(result[3], expectedOutput), "Expected: " + expectedOutput + "\n In Console: " + result[3]);    // Check the greeting message
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
