using UnityEngine;

public class GateFactory : MonoBehaviour, IFactory<Gate>
{
    public Gate Create(Gate template, Vector3 position)
    {
        return Instantiate(template, position, Quaternion.identity, transform);
    }
}
