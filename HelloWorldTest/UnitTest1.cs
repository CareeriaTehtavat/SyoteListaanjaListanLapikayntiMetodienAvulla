using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("10\n7\n", "Syota luku:\nIso luku\nSyota luku:\nPieni luku\n")] // Input: 10, then 7
        [InlineData("9\n8\n", "Syota luku:\nIso luku\nSyota luku:\nPieni luku\n")]   // Input: 9, then 8
        [InlineData("6\n", "Syota luku:\nPieni luku\n")]                            // Input: 6 (valid from the start)
        [Trait("TestGroup", "TestUserInput")]

        public void TestUserInput(string userInput, string expectedOutput)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Redirect console output

            var input = new StringReader(userInput);
            Console.SetIn(input); // Redirect user input

            // Act
            HelloWorld.Program.Main(new string[0]);

            // Assert
            var result = sw.ToString();
            Assert.True(LineContainsIgnoreSpaces(result, expectedOutput), $"Expected:\n{expectedOutput}\nBut got:\n{result}");
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
