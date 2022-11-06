public class AddGate : Gate
{
    protected override int GenerateRunnerCount(int count = 1)
    {
        return RunnerFactor;
    }
}
