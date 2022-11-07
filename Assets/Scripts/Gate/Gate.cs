using System;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    [SerializeField] private int _runnerFactor;
    protected int RunnerFactor => _runnerFactor;

    public event Action<int, Vector3> RunnerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BallMover mover))
        {
            RunnerEntered?.Invoke(GenerateRunnerCount(mover.RunnerCount), transform.position);
        }
    }

    protected abstract int GenerateRunnerCount(int count = 1);
}
    
