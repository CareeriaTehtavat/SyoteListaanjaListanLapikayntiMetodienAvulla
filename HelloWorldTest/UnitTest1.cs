using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Fact]
        [Trait("TestGroup", "InputValidation")]
        public void TestConsoleOutputContainsMoreThanTwoLinesWithText()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Debug output to see the actual result
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Line {i}: '{result[i]}'");
            }

            // Check if there are more than 2 lines
            Assert.True(result.Length > 2, "The output does not contain more than 2 lines.");
            Assert.False(string.IsNullOrWhiteSpace(result[0]), "One of the lines does not contain any text.");
            Assert.False(string.IsNullOrWhiteSpace(result[1]), "One of the lines does not contain any text.");
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
