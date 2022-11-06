public class MultiplyingGate : Gate
{
    protected override int GenerateRunnerCount(int count = 1)
    {
        return RunnerFactor * count;
    }
}
