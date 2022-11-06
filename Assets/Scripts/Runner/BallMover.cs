using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Spawner _spawner;
    private Camera _camera;
    private bool _moveByTouch;
    private List<Transform> _balls;
    public int RunnerCount => _balls.Count;

    private void Awake()
    {
        _balls = new List<Transform>();
        
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _spawner.BallSpawned += OnBallSpawned;
    }
    
    private void OnDisable()
    {
        _spawner.BallSpawned -= OnBallSpawned;
    }

    private void OnBallSpawned(Transform ball)
    {
        _balls.Add(ball);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            _moveByTouch = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _moveByTouch = false;
        }

        if (_moveByTouch)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit))
            {
                var newPosition = hit.point;
   
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, 
                    Time.deltaTime * _speed), transform.position.y, transform.position.z);
            }
        }
    }
}
