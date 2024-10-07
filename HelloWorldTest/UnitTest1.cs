using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("auto\nvene\nkukka\nlopeta\n",
             "Sanassa on parillinen maara kirjaimia\nSanassa on parillinen maara kirjaimia\nSanassa on pariton maara kirjaimia\n")]

        [InlineData("omena\nomena\nomena\nlopeta\n",
            "Sanassa on pariton maara kirjaimia\nSanassa on pariton maara kirjaimia\nSanassa on pariton maara kirjaimia\n")]
        [Trait("TestGroup", "Test_MultipleWords_And_ExitCondition")]

        public void Test_MultipleWords_And_ExitCondition(string input, string expectedOutput)
        {
            // Arrange: Asetetaan syöte ja tulosteen tallennus
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act: Ajetaan ohjelma
            HelloWorld.Program.Main(null);

            // Vähennetään turhat kehotukset ja verrataan vain olennaista tulostetta
            var actualOutput = outputWriter.ToString();

            // Suodatetaan pois kehotusrivit ("Syötä sana...")
            string filteredOutput = string.Join("\n", actualOutput
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                .Where(line => !line.StartsWith("Syötä sana"))); // suodatetaan kehotusrivit

            // Assert: Verrataan tulostetta odotettuun tulosteeseen
            Assert.True(LineContainsIgnoreSpaces(expectedOutput, filteredOutput), "Expected: " + expectedOutput
                + " Actual: " + actualOutput);
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
