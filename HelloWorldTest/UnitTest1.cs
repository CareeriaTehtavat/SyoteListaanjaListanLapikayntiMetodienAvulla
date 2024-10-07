using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("Toyota\nHonda\nFord\nBMW\nTesla\n", "Toyota", "Honda", "Ford", "BMW", "Tesla")]
        [InlineData("BMW\nJaguar\nAudi\nMercedes\nVolvo\n", "BMW", "Jaguar", "Audi", "Mercedes", "Volvo")]
        [Trait("TestGroup", "AutoList")]
        public void AutoList(string userInput, string brand1, string brand2, string brand3, string brand4, string brand5)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Simulate user input for car brands
            var input = new StringReader(userInput);
            Console.SetIn(input); // Mock the user input

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Debug output to see the actual result
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Line {i}: '{result[i]}'");
            }

            // Assert the output contains the 5 expected car brands
            Assert.True(result.Length >= 8, "The output does not contain enough lines.");

            // Check that the console output lists the car brands correctly
            Assert.Contains(brand1, result);
            Assert.Contains(brand2, result);
            Assert.Contains(brand3, result);
            Assert.Contains(brand4, result);
            Assert.Contains(brand5, result);
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
        private string NormalizeOutput(string output)
        {
            // Normalize line endings to Unix-style '\n' and trim any extra spaces or newlines
            return output.Replace("\r\n", "\n").Trim();
        }
    }
}