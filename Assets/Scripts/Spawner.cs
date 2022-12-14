using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Runner _runnerTemplate;
    [SerializeField] private Gate[] _gateTemplates;
    [SerializeField] private float _distanceFactor;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _player;
    [SerializeField] private GateFactory _gateFactory;
    [SerializeField] private int _gateCount; // сделать настройки из скрипта как-то  типо скриптейбл
    [SerializeField] private Vector3 _distanceBetweenGates;
    [SerializeField] private Vector3 _xOffset;
    [SerializeField] private Transform _startSpawn;
    [SerializeField] private Transform _gatesContainer;
    private readonly List<Gate> _gates = new List<Gate>();
    public event Action<Transform> BallSpawned;

    private void Start()
    {
        BallSpawned?.Invoke(_player.transform);

        for (int i = 0; i < _gateCount; i++)
        {
            // можно эжту всю логикцу засунуть в скриптейбл или чето подобное, т.е
            //все что должен спавнер делать это спавнить, а данные получить из конфига
            var idx = Random.Range(0, _gateTemplates.Length);
            var idx1 = Random.Range(0, _gateTemplates.Length);
            
            var gate = _gateFactory.Create(_gateTemplates[idx], _startSpawn.position);
            var gate1 = _gateFactory.Create(_gateTemplates[idx1], _startSpawn.position + _distanceBetweenGates);

            _gates.Add(gate);
            _gates.Add(gate1);
            
            gate.View.Init(gate.RunnerFactor);
            gate1.View.Init(gate1.RunnerFactor);

            gate.RunnerEntered += OnRunnerEntered;
            gate1.RunnerEntered += OnRunnerEntered;

            _startSpawn.position += _xOffset;
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
            var ball = Instantiate(_runnerTemplate, spawnPosition, Quaternion.identity, transform);
            ball.Init(_player.transform);

            var x = _distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var z = _distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);
            
            var newPos = new Vector3(x + 0.1f, 0f, z);

            ball.transform.DOLocalMove(newPos, 0.5f).SetEase(Ease.OutBack);
            
            BallSpawned?.Invoke(ball.transform);
        }
    }
}
