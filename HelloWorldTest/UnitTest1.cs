using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("4\n", new[] { "Anna luku: Kertotaulu luvulle 4:", "1 * 4 = 4", "2 * 4 = 8", "3 * 4 = 12", "4 * 4 = 16", "5 * 4 = 20", "6 * 4 = 24", "7 * 4 = 28", "8 * 4 = 32", "9 * 4 = 36", "10 * 4 = 40" })]
        [InlineData("3\n", new[] { "Anna luku: Kertotaulu luvulle 3:", "1 * 3 = 3", "2 * 3 = 6", "3 * 3 = 9", "4 * 3 = 12", "5 * 3 = 15", "6 * 3 = 18", "7 * 3 = 21", "8 * 3 = 24", "9 * 3 = 27", "10 * 3 = 30" })]
        [Trait("TestGroup", "TestMainMethod_OutputForGivenInput")]

        public void TestMainMethod_OutputForGivenInput(string userInput, string[] expectedOutput)
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            using var sr = new StringReader(userInput);
            Console.SetIn(sr); // Simulate user input

            // Act
            HelloWorld.Program.Main(new string[0]);

            // Get the console output, split by new lines, and remove empty or whitespace lines
            var result = sw.ToString()
                            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                            .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove any blank lines
                            .ToArray();

            // Ensure the number of lines matches
            //Assert.Equal(expectedOutput.Length, result.Length);

            // Compare each row of the expected and actual output
            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.True(LineContainsIgnoreSpaces(result[i], expectedOutput[i]),
                    $"Expected line: '{expectedOutput[i]}', but got: '{result[i]}'");
            }
        }

        [Theory]
        [InlineData(3, 4, "3 * 4 = 12")]
        [InlineData(5, 6, "5 * 6 = 30")]
        [InlineData(10, 10, "10 * 10 = 100")]
        [Trait("TestGroup", "TestKertolaskukaavalla")]

        public void TestKertolaskukaavalla(int luku1, int luku2, string expectedOutput)
        {
            // Act
            string result = HelloWorld.Program.Kertolaskukaavalla(luku1, luku2);

            // Assert
            Assert.True(LineContainsIgnoreSpaces(result, expectedOutput), $"Expected:\n{expectedOutput}\nBut got:\n{result}");
        }
        private bool LineContainsIgnoreSpaces(string line, string expectedText)
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
        private string NormalizeOutput(string output)
        {
            // Normalize line endings to Unix-style '\n' and trim any extra spaces or newlines
            return output.Replace("\r\n", "\n").Trim();
        }
    }
}
