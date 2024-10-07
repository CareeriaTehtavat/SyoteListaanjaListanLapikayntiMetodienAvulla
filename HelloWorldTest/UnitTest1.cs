using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("15", "2", "5", "Suurin luku on: 15", "Pienin luku on: 2")]
        [InlineData("2", "345", "1987", "Suurin luku on: 1987", "Pienin luku on: 2")]
        [InlineData("33", "66", "12", "Suurin luku on: 66", "Pienin luku on: 12")]
        [Trait("TestGroup", "Test_SanaManipulations")]

        public void Test_SanaManipulations(string nimi, string harrastus, string kaupunki, string expectedOutput, string pieninOutput)
        {
            // Arrange: Simulate console input
            var inputReader = new StringReader(nimi + '\n' + kaupunki + "\n" + harrastus + "\n");
            Console.SetIn(inputReader);

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act: Run the main program
            HelloWorld.Program.Main(null);

            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                         .Where(line => !string.IsNullOrWhiteSpace(line))
                         .ToArray();


            // Assert: Verify output
            Assert.True(LineContainsIgnoreSpaces(expectedOutput, result[3]), "Expected: " + expectedOutput
                + " printed: " + result[3]);
            Assert.True(LineContainsIgnoreSpaces(pieninOutput, result[4]), "Expected: " + pieninOutput
                + " printed: " + result[4]);

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

