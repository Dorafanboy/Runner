using System;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    [field:SerializeField] public int RunnerFactor { get; private set; }

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
    
