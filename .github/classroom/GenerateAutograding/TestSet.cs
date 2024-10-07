namespace GenerateAutograding;

internal sealed class TestSet
{
    private readonly string _startupProject;

    public TestSet(string startupProject) => _startupProject = startupProject;

    public IReadOnlyList<Test> Tests => new Test[]
    {

        new DotnetTestGroup("NumeromuuttujillaPeruslaskut")
        {
            Points = 60
        },
        new DotnetTestGroup("ErotusTest")
        {
            Points = 10

        }, new DotnetTestGroup("OsamaaraTest")
        {
            Points = 10

        },new DotnetTestGroup("TuloTest")
        {
            Points = 10

        },new DotnetTestGroup("TestSumma")
        {
            Points = 10
        },
    };
}
