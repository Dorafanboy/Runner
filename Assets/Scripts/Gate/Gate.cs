using System;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    [SerializeField] private GateView _view;
    [SerializeField] private int _runnerFactor;
    public int RunnerFactor => _runnerFactor;
    public event Action<int, Vector3> RunnerEntered;
    public GateView View => _view;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BallMover mover))
        {
            RunnerEntered?.Invoke(GenerateRunnerCount(mover.RunnerCount), transform.position);
        }
    }

    protected abstract int GenerateRunnerCount(int count = 1);
}
    
