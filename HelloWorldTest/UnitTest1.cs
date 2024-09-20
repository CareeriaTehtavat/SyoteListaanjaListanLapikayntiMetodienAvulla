using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Fact]
        [Trait("TestGroup", "TestNumberPrinting")]
        public void TestNumberPrinting()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output and normalize line endings
            var result = NormalizeLineEndings(sw.ToString());

            // Prepare expected output (with normalized line endings)
            var expectedOutput = NormalizeLineEndings(string.Join("\r\n", Enumerable.Range(1, 10)) + "\r\n");

            // Split the actual and expected outputs into lines
            var actualLines = result.Split('\n');
            var expectedLines = expectedOutput.Split('\n');

            // Assert: Check if the output matches the expected output line by line
            for (int i = 0; i < expectedLines.Length; i++)
            {
                Assert.Equal(expectedLines[i].Trim(), actualLines[i].Trim());
            }
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

        private string NormalizeLineEndings(string input)
        {
            // Normalize all line endings to '\n' for consistent comparison
            return input.Replace("\r\n", "\n").Trim();
        }
    }

}
