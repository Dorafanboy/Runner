using System;
using DG.Tweening;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Runner _template;
    [SerializeField] private float _distanceFactor;
    [SerializeField] private float _radius;
    [SerializeField] private Gate[] _gates;
    [SerializeField] private Transform _player;
    public event Action<Transform> BallSpawned;

    private void Start()
    {
        BallSpawned?.Invoke(_player.transform);
    }

    private void OnEnable()
    {
        foreach (var gate in _gates)
        {
            gate.RunnerEntered += OnRunnerEntered;
        }
    }
    
    private void OnDisable()
    {
        foreach (var gate in _gates)
        {
            gate.RunnerEntered -= OnRunnerEntered;
        }
    } 

    private void OnRunnerEntered(int spawnCount, Vector3 spawnPosition)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var ball = Instantiate(_template, spawnPosition, Quaternion.identity, transform);
            
            ball.Init(_player.transform);

            var x = _distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var z = _distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);
            
            var newPos = new Vector3(x, 0f, z);

            ball.transform.DOLocalMove(newPos, 0.5f).SetEase(Ease.OutBack);
            
            BallSpawned?.Invoke(ball.transform);
        }
    }
}
