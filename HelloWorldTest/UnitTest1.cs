using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("pekka", "saara", "pauli",
                    "Nimet pienilla alkukirjaimilla: pekka, saara, pauli\nNimet isoilla alkukirjaimilla: Pekka, Saara, Pauli\n")]
        [InlineData("janne", "matti", "juho",
                    "Nimet pienilla alkukirjaimilla: janne, matti, juho\nNimet isoilla alkukirjaimilla: Janne, Matti, Juho\n")]
        [Trait("TestGroup", "Test_NameFormatting")]

        public void Test_NameFormatting(string firstName, string secondName, string thirdName, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{firstName}\n{secondName}\n{thirdName}\n");
            Console.SetIn(input);

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Main(null);

            // Assert
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);


            Assert.True(LineContainsIgnoreSpaces(expectedOutput, result[result.Length - 3] + "\n" + result[result.Length - 2]), "expected " + expectedOutput
                + " got: " + result[result.Length - 3] + "\n" + result[result.Length - 2]);



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


