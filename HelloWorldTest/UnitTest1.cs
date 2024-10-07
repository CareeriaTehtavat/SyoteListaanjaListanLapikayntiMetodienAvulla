
using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Audi\nVantaa\nHelsinki\nSuomi\nEurooppa\n", new[] { "Audi", "Vantaa", "Helsinki", "Suomi", "Eurooppa" })]
        [InlineData("Alice\nBob\nCharlie\nDavid\nEve\n", new[] { "Alice", "Bob", "Charlie", "David", "Eve" })]
        [Trait("TestGroup", "TestAddNamesToList")]

        public void TestAddNamesToList(string userInput, string[] expectedOutput)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            using var sr = new StringReader(userInput);
            Console.SetIn(sr); // Simulate user input

            // Act
            HelloWorld.Program.Main(new string[0]);

            // Get the console output and split by new lines
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                                     .Where(line => !string.IsNullOrWhiteSpace(line))
                                     .ToArray();

            // Ensure the number of lines matches

            // Compare each row of the expected and actual output
            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.True(LineContainsIgnoreSpaces(result[i + 1], expectedOutput[i]));
            }
        }

        [Fact]
        public void TestListPopulation()
        {
            // Arrange
            var userInput = new[] { "Audi", "Vantaa", "Helsinki", "Suomi", "Eurooppa" };
            var list = new List<string>();

            // Act
            foreach (var name in userInput)
            {
                list = HelloWorld.Program.LisaaHenkilo(list, name);
            }

            // Assert
            Assert.Equal(userInput.Length, list.Count);
            for (int i = 0; i < userInput.Length; i++)
            {
                Assert.True(LineContainsIgnoreSpaces(userInput[i], list[i]));
            }
        }
        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"[\s.,]+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"[\s.,]+", "").ToLower();

            // Create a regex pattern to allow any character for "ä", "ö", "a", and "o"
            string pattern = Regex.Escape(normalizedExpectedText)
                                  .Replace("ö", ".")  // Allow any character for "ö"
                                  .Replace("ä", ".")  // Allow any character for "ä"
                                  .Replace("a", ".")  // Allow any character for "a"
                                  .Replace("o", ".");  // Allow any character for "o"

            // Check if the line matches the pattern, ignoring case
            return Regex.IsMatch(normalizedLine, pattern, RegexOptions.IgnoreCase);
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
