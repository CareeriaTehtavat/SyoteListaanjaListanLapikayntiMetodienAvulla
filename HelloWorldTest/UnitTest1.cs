
using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("nikke\nonni\neemeli\nnia\naalto yliopisto\n", new[] { "nikke", "onni", "eemeli", "nia", "aalto yliopisto" })]
        [InlineData("alice\nbob\ncharlie\ndavid\neve\n", new[] { "alice", "bob", "charlie", "david", "eve" })]
        [InlineData("john\ndoe\nmichael\njane\nsmith\n", new[] { "john", "doe", "michael", "jane", "smith" })]
        [Trait("TestGroup", "TestNameListOutput")]

        public void TestNameListOutput(string userInput, string[] expectedOutput)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Redirect console output

            var input = new StringReader(userInput);
            Console.SetIn(input); // Redirect user input

            // Act
            HelloWorld.Program.Main(new string[0]); // Assuming the list logic is in Main

            // Get the console output, split by new lines, and remove empty or whitespace lines
            var result = sw.ToString()
                           .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                           .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove any blank lines
                           .ToArray();

            // Skip the first line of the result, which contains the prompt "Anna 5 henkilön nimeä:"
            var actualNames = result.Skip(1).ToArray();

            // Ensure the number of lines matches
            Assert.Equal(expectedOutput.Length, actualNames.Length);

            // Compare each row of the expected and actual output
            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.True(LineContainsIgnoreSpaces(expectedOutput[i], actualNames[i]),
                    $"Expected line: '{expectedOutput[i]}', but got: '{actualNames[i]}'");
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
