using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Moi15", "Kirjainten maara: 3", "Numeroiden maara: 2")]
        [InlineData("343432", "Kirjainten maara: 0", "Numeroiden maara: 6")]
        [InlineData("Kuka sina olet", "Kirjainten maara: 12", "Numeroiden maara: 0")]
        [Trait("TestGroup", "Test_SanaManipulations")]

        public void Test_SanaManipulations(string nimi, string expectedOutput, string pieninOutput)
        {
            // Arrange: Simulate console input
            var inputReader = new StringReader(nimi + '\n');
            Console.SetIn(inputReader);

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act: Run the main program
            HelloWorld.Program.Main(null);

            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                         .Where(line => !string.IsNullOrWhiteSpace(line))
                         .ToArray();


            // Assert: Verify output
            Assert.True(LineContainsIgnoreSpaces(expectedOutput, result[1]), "Expected: " + expectedOutput
                + " printed: " + result[1]);
            Assert.True(LineContainsIgnoreSpaces(pieninOutput, result[2]), "Expected: " + pieninOutput
                + " printed: " + result[2]);

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