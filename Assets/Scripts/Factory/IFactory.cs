using UnityEngine;

public interface IFactory<T>
{
    T Create(T template, Vector3 position);
}
