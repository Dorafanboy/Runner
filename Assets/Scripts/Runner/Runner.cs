using UnityEngine;

public class Runner : MonoBehaviour
{
    public void Init(Transform target)
    {
        transform.parent = target;
    }
}
