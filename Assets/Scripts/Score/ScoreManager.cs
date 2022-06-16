using Savers;
using UI;

namespace Gameplay
{
    public class ScoreManager : IScoreManager<int>
    {
        // На больших проектах можно применить шаблон типа MVC, а конструктор объекта вызывать при общей инициализации игры (вместе с остальными менеджерами)
        // На небольшом тестовом - "И так сойдет".
        public static ScoreManager Inst;

        private int _score = 0; //current score
        private int _bestScore;
        private UIBestScore _uiScore;

        private ISaver<int> _saver;
        const string saverKey = "BestScore";


        public ScoreManager(UIBestScore uiScore)
        {
            Inst = this;

            _uiScore = uiScore;
            _saver = new PlayerPrefsIntSaver(saverKey);
            TryLoad();
        }


        public void IncreaseScore(int value)
        {
            _score += value;
            OnScoreChanged();
        }

        public void DecreaseScore(int value)
        {
            _score -= value;
            OnScoreChanged();
        }

        private void OnScoreChanged()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
                _uiScore.UpdateScoreText(_bestScore);
            }            
        }

        private void TrySave()
        {
            _saver.Save(_bestScore);
        }

        private void TryLoad()
        {
            _bestScore = _saver.Load();
            _uiScore.UpdateScoreText(_bestScore);
        }

        public void SaveBestScore()
        {
            TrySave();
        }
    }
}