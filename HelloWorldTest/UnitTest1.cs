using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Fact]
        public void TestNumerolistaFirstFifthAndTenthPrintedCorrectly()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Simulate user input of 10 numbers
            var simulatedInput = new StringReader("1\n2\n3\n4\n5\n6\n7\n8\n9\n10");
            Console.SetIn(simulatedInput);

            // Act
            HelloWorld.Program.Main(new string[0]); // Call Main method

            // Capture output and split it by line
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert: Checking the correct numbers printed for 1st, 5th, and 10th
            Assert.True(LineContainsIgnoreSpaces("Syota listalle lukuja, kunnes lista on valmis (10kpl)", result[0]));
            Assert.True(LineContainsIgnoreSpaces("Listan ensimmainen, viides ja kymmenes luku:", result[1]));
            Assert.Equal("1", result[2]);  // First number
            Assert.Equal("5", result[3]);  // Fifth number
            Assert.Equal("10", result[4]); // Tenth number
        }

        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

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


