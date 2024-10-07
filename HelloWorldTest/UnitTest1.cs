using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Fact]
        [Trait("TestGroup", "Main_ShouldPrintSquare_WhenUserProvidesInput")]

        public void Main_ShouldPrintSquare_WhenUserProvidesInput()
        {
            // Arrange
            var input = "5";  // Simulating user input of 5
            var expectedOutput = "*****\n*   *\n*   *\n*   *\n*****\n";

            // Redirect input
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);

                // Redirect output
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    // Act
                    HelloWorld.Program.Main(new string[0]);

                    // Assert
                    var result = sw.ToString();
                    Assert.Contains("Kuinka ison ", result);  // Ensure it asks for input
                    Assert.Contains(expectedOutput, result);  // Check that the output matches expected square pattern
                }
            }
        }
        [Theory]
        [InlineData(3, new[] { "***", "* *", "***" })]
        [InlineData(4, new[] { "****", "*  *", "*  *", "****" })]
        [InlineData(5, new[] { "*****", "*   *", "*   *", "*   *", "*****" })]
        [Trait("TestGroup", "TulostaNelio_ShouldPrintCorrectSquare")]

        public void TulostaNelio_ShouldPrintCorrectSquare(int sivunPituus, string[] expectedLines)
        {
            // Redirect output to capture the printed square
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                HelloWorld.Program.TulostaNelio(sivunPituus);

                // Assert
                var result = sw.ToString();

                // Split the result by newlines and remove any empty lines at the end
                var resultLines = result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Ensure that the number of rows matches the expected number of rows
                Assert.Equal(expectedLines.Length, resultLines.Length);

                // Check if each row contains the expected number of stars
                for (int i = 0; i < expectedLines.Length; i++)
                {
                    var expectedRow = expectedLines[i].Replace(" ", "");
                    var actualRow = resultLines[i].Replace(" ", "");

                    // Assert that the number of stars in the actual row matches the expected number of stars
                    Assert.Equal(expectedRow, actualRow);
                }
            }
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


