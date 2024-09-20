using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Tammikuu", "Sininen", "3", "Pelinimesi on Lumisateen Sininen Kaapio.")]
        [InlineData("Huhtikuu", "Punainen", "7", "Pelinimesi on Aamukasteen Punainen Haltija.")]
        [InlineData("Joulukuu", "Musta", "12", "Pelinimesi on Lumisateen Musta Ewok.")]

        [Trait("TestGroup", "TestNicknameGeneration")]
        public void TestNicknameGeneration(string kuukausi, string vari, string paiva, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{kuukausi}\n{vari}\n{paiva}\n"); // Simulate user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString();

            // Split the output into lines
            var resultLines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert: Check the final output for correctness
            var lastLine = resultLines[1];
            Assert.True(LineContainsIgnoreSpaces(lastLine, expectedOutput),
                $"Expected: {expectedOutput} but got: {lastLine}");
        }


        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

            // Normalize both the actual output and the expected text by replacing 'ä' -> 'a' and 'ö' -> 'o'
            normalizedLine = normalizedLine.Replace("ä", "a").Replace("ö", "o");
            normalizedExpectedText = normalizedExpectedText.Replace("ä", "a").Replace("ö", "o");

            // Check if the normalized line matches the normalized expected text
            return normalizedLine == normalizedExpectedText;
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