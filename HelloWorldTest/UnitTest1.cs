using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5, 3, "5 on suurempi kuin 3")]
        [InlineData(2, 4, "2 on pienempi kuin 4")] // Updated expected text
        [InlineData(7, 7, "7 on yhtä suuri kuin 7")]
        [Trait("TestGroup", "TestNumberComparison")]
        public void TestNumberComparison(int num1, int num2, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{num1}\n{num2}\n"); // Simulate user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output and split it into lines
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Debug output to see what the actual result contains
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Line {i}: {result[i]}");
            }

            // Assert: Find the correct line with the comparison result (e.g., 2nd or 3rd line)
            Assert.True(result.Length > 2, "Expected at least 3 lines of output.");

            // Check the result at index 2 or whichever line contains the comparison output
            Assert.True(LineContainsIgnoreSpaces(result[2], expectedOutput),
                $"Expected: {expectedOutput} but got: {result[2]}");
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