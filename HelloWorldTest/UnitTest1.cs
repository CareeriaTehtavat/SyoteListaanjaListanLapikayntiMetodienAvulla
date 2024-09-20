using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]

        [InlineData(30, "Vielä pitää säästää")]
        [InlineData(50, "Sinulla on varaa hankkia Motorola G51")]
        [InlineData(75, "Sinulla on varaa hankkia Motorola G51")]
        [InlineData(199, "Sinulla on varaa hankkia Motorola G51")]
        [InlineData(200, "Sinulla on varaa hankkia Samsung Galaxy")]
        [InlineData(400, "Sinulla on varaa hankkia Samsung Galaxy")]
        [InlineData(500, "Sinulla on varaa hankkia Tietokone, PS5 tai iPhone 11")]
        [InlineData(999, "Sinulla on varaa hankkia Tietokone, PS5 tai iPhone 11")]
        [InlineData(1500, "Sinulla on varaa hankkia parempi tietokone tai iPhone 14")]
        [InlineData(2000, "Voit hankkia useamman eri laitteen")]
        [InlineData(5000, "Voit hankkia useamman eri laitteen")]
        [Trait("TestGroup", "TestMoneyComparison")]
        public void TestMoneyComparison(double money, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{money}\n"); // Simulate user input
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString();
            Console.WriteLine("Captured output:");
            Console.WriteLine(result);

            // Split the output into lines
            var resultLines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);


            var lastLine = resultLines[0];
            Assert.True(LineContainsIgnoreSpaces(lastLine, expectedOutput),
                $"Expected: {expectedOutput} but got: {lastLine}");
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
        private string NormalizeOutput(string output)
        {
            // Normalize line endings to Unix-style '\n' and trim any extra spaces or newlines
            return output.Replace("\r\n", "\n").Trim();
        }
    }
}
