
using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("2")]
        [InlineData("16")]
        [InlineData("3332")]
        [InlineData("102")]
        [Trait("TestGroup", "Kertotaulu")]
        public void Kertotaulu(string inputNumber)
        {
            // Arrange
            var input = new StringReader(inputNumber); // Simulate user input for the number
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Prepare expected multiplication table output
            int number = int.Parse(inputNumber);
            var expectedOutput = new List<string>
    {
        $"Antamasi luvun ({number}) kertotaulu:",
        $"{number} * 1  = {number * 1}",
        $"{number} * 2  = {number * 2}",
        $"{number} * 3  = {number * 3}",
        $"{number} * 4  = {number * 4}",
        $"{number} * 5  = {number * 5}",
        $"{number} * 6  = {number * 6}",
        $"{number} * 7  = {number * 7}",
        $"{number} * 8  = {number * 8}",
        $"{number} * 9  = {number * 9}",
        $"{number} * 10 = {number * 10}"
    };

            // Assert that the correct prompt is shown
            Assert.False(string.IsNullOrEmpty(result[0]), "The first line should not be null or empty.");
            //Assert.True(LineContainsIgnoreSpaces(result[0], "Syötä valitsemasi luku:"), "The prompt message did not match.");

            // Assert that each line of output matches the expected multiplication table
            for (int i = 1; i < expectedOutput.Count + 1; i++) // Starting from line 1 as the first line is the prompt
            {
                Assert.True(LineContainsIgnoreSpaces(result[i], expectedOutput[i - 1]),
                    $"Expected: {expectedOutput[i - 1]} but got: {result[i]}");
            }
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