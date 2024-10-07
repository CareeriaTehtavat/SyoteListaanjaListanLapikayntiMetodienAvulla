using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Fact]
        [Trait("TestGroup", "List2")]
        public void List2()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Assuming the game list logic is in Main

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            // We assume that the first half of the list is printed in original order, followed by the reverse
            int listEnd = result.Length / 2; // Since it's printed twice, the mid-point splits them

            var firstHalf = result.Take(listEnd).ToArray(); // The list in the original order
            var secondHalf = result.Skip(listEnd).Take(listEnd).ToArray(); // The list in reverse order

            // Assert that the second half is the reverse of the first half
            Assert.Equal(firstHalf.Reverse(), secondHalf);
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