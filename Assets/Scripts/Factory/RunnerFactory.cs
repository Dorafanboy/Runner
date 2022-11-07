using UnityEngine;

public class RunnerFactory : MonoBehaviour, IFactory<Runner>
{
    public Runner Create(Runner template, Vector3 position)
    {
        return Instantiate(template, transform);
    }
}
