using System;
using UnityEngine;

[RequireComponent(typeof(Runner))]
[RequireComponent(typeof(Renderer))]
public class BallStacker : MonoBehaviour
{
    private Runner _ball;
    private Material _ballColor;
    public event Action<Transform> BallAdded;

    private void Start()
    {
        _ball = GetComponent<Runner>();
        BallAdded?.Invoke(_ball.transform);
        _ballColor = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Runner ball))
        {
            BallAdded?.Invoke(ball.transform);
            ball.Init(transform);
        }
    }
}
