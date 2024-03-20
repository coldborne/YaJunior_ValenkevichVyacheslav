namespace Shop
{
    public interface ICopyable<T>
    {
        T DeepCopy();
    }
}