namespace GenerateAutograding;

internal sealed class TestSet
{
    private readonly string _startupProject;

    public TestSet(string startupProject) => _startupProject = startupProject;

    public IReadOnlyList<Test> Tests => new Test[]
    {
        
        new DotnetTestGroup("Test_SanaManipulations")
        {
            Points = 50
        },
         new DotnetTestGroup("Test_Muutos")
        {
            Points = 50
        },
    };
}
