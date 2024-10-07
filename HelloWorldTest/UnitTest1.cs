using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        // Additional Unit Test for validating output structure
        [Fact]
        [Trait("TestGroup", "NumeromuuttujillaPeruslaskut")]
        public void NumeromuuttujillaPeruslaskut()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Main(new string[0]);

            // Get console output
            var result = sw.ToString().TrimEnd();
            var resultLines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Expected values (you can adjust these based on actual numbers in "numerot")
            string expectedSum = "Summa: 12";
            string expectedDiff = "Erotus: -6";
            string expectedQuotient = "Osamaara: 0.15";
            string expectedProduct = "Tulo: 60";

            // Assert that each line matches the expected value, allowing for flexibility with dots or commas
            Assert.True(LineContainsIgnoreSpaces(expectedSum, resultLines[0]), $"Expected: {expectedSum}, Actual: {resultLines[0]}");
            Assert.True(LineContainsIgnoreSpaces(expectedDiff, resultLines[1]), $"Expected: {expectedDiff}, Actual: {resultLines[1]}");
            Assert.True(LineContainsIgnoreSpaces(expectedQuotient, resultLines[2]), $"Expected: {expectedQuotient}, Actual: {resultLines[2]}");
            Assert.True(LineContainsIgnoreSpaces(expectedProduct, resultLines[3]), $"Expected: {expectedProduct}, Actual: {resultLines[3]}");
        }
        [Fact]
        [Trait("TestGroup", "TestSumma")]
        public void TestSummaFunction()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Summa(new int[] { 10, 3, 2 });

            // Get the output that was written to the console
            var result = sw.ToString().TrimEnd();
            string expectedDifference = "Summa: 15";

            // Assert: Check if the result matches the expected difference output
            Assert.True(LineContainsIgnoreSpaces(expectedDifference, result),
                $"Expected: {expectedDifference}, Actual: {result}");
        }

        [Fact]
        [Trait("TestGroup", "ErotusTest")]
        public void TestErotusFunction()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Erotus(new int[] { 10, 3, 2 });

            // Get the output that was written to the console
            var result = sw.ToString().TrimEnd();
            string expectedDifference = "Erotus: 5";

            // Assert: Check if the result matches the expected difference output
            Assert.True(LineContainsIgnoreSpaces(expectedDifference, result),
                $"Expected: {expectedDifference}, Actual: {result}");
        }

        // Test for Osamaara function
        [Fact]
        [Trait("TestGroup", "OsamaaraTest")]
        public void TestOsamaaraFunction()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Osamaara(new int[] { 12, 2, 4 });

            // Get the output that was written to the console
            var result = sw.ToString().TrimEnd();
            string expectedQuotient = "Osamaara: 1.5";

            // Assert: Check if the result matches the expected quotient output
            Assert.True(LineContainsIgnoreSpaces(expectedQuotient, result),
                $"Expected: {expectedQuotient}, Actual: {result}");
        }

        // Test for Tulo function
        [Fact]
        [Trait("TestGroup", "TuloTest")]
        public void TestTuloFunction()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            HelloWorld.Program.Tulo(new int[] { 3, 4, 5 });

            // Get the output that was written to the console
            var result = sw.ToString().TrimEnd();
            string expectedProduct = "Tulo: 60";

            // Assert: Check if the result matches the expected product output
            Assert.True(LineContainsIgnoreSpaces(expectedProduct, result),
                $"Expected: {expectedProduct}, Actual: {result}");
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


