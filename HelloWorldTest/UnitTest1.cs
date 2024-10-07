using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("anton\nArtemii\n", "nntoa"
            , "AArtemiiA")]
        [Trait("TestGroup", "Test_SanaManipulations")]

        public void Test_SanaManipulations(string input, string expectedOutput, string sana2Expected)
        {
            // Arrange: Simulate console input
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act: Run the main program
            HelloWorld.Program.Main(null);

            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                         .Where(line => !string.IsNullOrWhiteSpace(line))
                         .ToArray();


            // Assert: Verify output
            Assert.True(LineContainsIgnoreSpaces(expectedOutput, result[4]), "Expected: " + expectedOutput
                + " printed: " + result[4]);
            Assert.True(LineContainsIgnoreSpaces(sana2Expected, result[6]), "Expected: " + expectedOutput
                + " printed: " + result[6]);
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

    }
}


