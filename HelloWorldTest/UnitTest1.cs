using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("vdf", "dsfsdf", "avain",
            "Kirjoita joku seuraavista sanoista ja paina enter.\nkello\ntalo\navain\n" +
            "vdf on virheellinen syote, kirjoita joku seuraavista ja paina enter.\nkello\ntalo\navain\n" +
            "dsfsdf on virheellinen syote, kirjoita joku seuraavista ja paina enter.\nkello\ntalo\navain\n" +
            "Olen viesti-niminen muuttuja avain\nOlen viesti-niminen muuttuja avain Olen viesti-niminen muuttuja avain\navain")]
        [Trait("TestGroup", "InputValidation")]
        public void TestUserInput(string firstInvalidInput, string secondInvalidInput, string validInput, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{firstInvalidInput}\n{secondInvalidInput}\n{validInput}\n");
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output and normalize line endings
            var result = NormalizeOutput(sw.ToString());
            var expected = NormalizeOutput(expectedOutput);

            // Assert
            Assert.True(LineContainsIgnoreSpaces(result, expected),
                $"Expected: {expected} but got: {result}");
        }

        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

            // Create a regex pattern to allow any character for "ä" and "ö"
            string pattern = Regex.Escape(normalizedExpectedText)
                                  .Replace("ö", ".")  // Allow any character for "ö"
                                  .Replace("ä", ".") // Allow any character for "ä"
                                  .Replace("a", ".") // Allow any character for "ä"
                                  .Replace("o", "."); // Allow any character for "ä"

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