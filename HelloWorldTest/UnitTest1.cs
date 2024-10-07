using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("Toyota\nHonda\nFord\nBMW\nTesla\nX\n", "Kiitos listan tayttamisesta!")]
        [InlineData("BMW\nJaguar\nAudi\nMercedes\nVolvo\nx\n", "Kiitos listan tayttamisesta!")]
        [Trait("TestGroup", "AutoList_AddFiveBrands")]

        public void AutoList_AddFiveBrands(string userInput, string expectedOutput)
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
            var result = sw.ToString();

            // Assert that the output matches the expected output
            Assert.True(LineContainsIgnoreSpaces(expectedOutput, result));
        }
        private bool LineContainsIgnoreSpaces(string expectedText, string line)
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