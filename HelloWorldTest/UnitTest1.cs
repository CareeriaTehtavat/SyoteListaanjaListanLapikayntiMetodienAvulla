using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {


        [Theory]
        [InlineData("Ossi", "Hello Ossi!")]
        [InlineData("Anna", "Hello Anna!")]
        [InlineData("John", "Hello John!")]
        [Trait("TestGroup", "HelloNimi2")]
        public void HelloNimi2(string inputName, string expectedOutput)
        {
            // Arrange
            var input = new StringReader(inputName);
            Console.SetIn(input); // Simulate user input

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert
            Assert.True(LineContainsIgnoreSpaces(result[1], expectedOutput), "Expected: " + expectedOutput + "\n In Console: " + result[1]);    // Check the greeting message
        }
        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace from the line and the expected text
            string normalizedLine = Regex.Replace(line, @"\s+", "");
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "");
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

    }
}