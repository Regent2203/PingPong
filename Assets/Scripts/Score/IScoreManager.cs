namespace Gameplay
{
    public interface IScoreManager<T>
    {
        public void IncreaseScore(T value);
        public void DecreaseScore(T value);

        public void SaveBestScore();
    }
}
