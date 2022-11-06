using UnityEngine;

public class RunnerFactory : MonoBehaviour, IFactory<Runner>
{
    public Runner Create(Runner template)
    {
        return Instantiate(template, transform);
    }
}
