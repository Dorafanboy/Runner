public interface IFactory<T>
{
    T Create(T template);
}
