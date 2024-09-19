
using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("2", "7", "8",
            "Anna luku: \n22222\n2 2 2\n22222\n\nAnna toinen luku: Anna vielä kolmas luku: \n2 7 8\n2\n7\n8\n8 7 2")]
        [InlineData("5", "3", "1",
            "Anna luku: \n55555\n5 5 5\n55555\n\nAnna toinen luku: Anna vielä kolmas luku: \n5 3 1\n5\n3\n1\n1 3 5")]
        [Trait("TestGroup", "KuvioitaJaMuotoja")]
        public void KuvioitaJaMuotoja(string luku1, string luku2, string luku3, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{luku1}\n{luku2}\n{luku3}\n"); // Simulate user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get and normalize the console output
            var result = NormalizeOutput(sw.ToString());

            // Normalize the expected output
            var expected = NormalizeOutput(expectedOutput);

            // Assert
            Assert.True(LineContainsIgnoreSpaces(result, expected),
                $"Expected: {expectedOutput} but got: {sw.ToString()}");
        }

        private string NormalizeOutput(string output)
        {
            // Remove all whitespace and convert to lowercase
            return Regex.Replace(output, @"\s+", "").ToLower();
        }

        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

            // Create a regex pattern to allow any character for "ä" and "ö"
            string pattern = Regex.Escape(normalizedExpectedText)
                                  .Replace("ö", ".")  // Allow any character for "ö"
                                  .Replace("ä", "."); // Allow any character for "ä"

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

    }
}
