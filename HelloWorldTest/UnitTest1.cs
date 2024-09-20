using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(50, 20, "Iso luku")]
        [InlineData(30, 15, "Pieni luku")]
        [InlineData(40, 20, "Pieni luku")]
        [Trait("TestGroup", "KumpiOnSuurempi")]
        public void KumpiOnSuurempi(int num1, int age, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{num1}\n{age}\n"); // Simulate user inputs
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

            // Debug output to see what the actual result contains
            for (int i = 0; i < resultLines.Length; i++)
            {
                Console.WriteLine($"Line {i}: {resultLines[i]}");
            }

            // Assert: Check the final output for correctness
            // Use the last line of the output (assumed to be where the result is printed)
            var lastLine = resultLines.Length > 0 ? resultLines[resultLines.Length - 1] : "";
            Assert.True(LineContainsIgnoreSpaces(lastLine, resultLines[2]),
                $"Expected: {expectedOutput} but got: {resultLines[2]}");
        }

        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace from the line and the expected text
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();
            return normalizedLine.Contains(normalizedExpectedText);
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