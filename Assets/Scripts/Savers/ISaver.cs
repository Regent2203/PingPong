namespace Savers
{
    public interface ISaver<T>
    {
        public void Save(T value);
        public T Load();
    }
}