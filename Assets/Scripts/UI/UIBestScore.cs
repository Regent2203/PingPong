using Gameplay;
using Savers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBestScore : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText;

        private IScoreManager<int> _scoreManager;


        private void Awake()
        {
            //todo: in larger projects, managers should be instantiated in more appropriate places (in common application init)
            _scoreManager = new ScoreManager(this);
        }

        public void UpdateScoreText(int value)
        {
            _scoreText.text = $"Best: {value.ToString()}";
        }

        private void OnApplicationQuit()
        {
            _scoreManager.SaveBestScore();
        }
    }
}