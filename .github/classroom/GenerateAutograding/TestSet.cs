namespace GenerateAutograding;

internal sealed class TestSet
{
    private readonly string _startupProject;

    public TestSet(string startupProject) => _startupProject = startupProject;

    public IReadOnlyList<Test> Tests => new Test[]
    {
        
        new DotnetTestGroup("Main_ShouldPrintSquare_WhenUserProvidesInput")
        {
            Points = 50
        },
        new DotnetTestGroup("TulostaNelio_ShouldPrintCorrectSquare")
        {
            Points = 50
        },
    };
}
