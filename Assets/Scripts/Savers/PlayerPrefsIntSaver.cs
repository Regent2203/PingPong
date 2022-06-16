using UnityEngine;

namespace Savers
{
    public class PlayerPrefsIntSaver : ISaver<int>
    {
        protected string _key;

        public PlayerPrefsIntSaver(string key)
        {
            _key = key;
        }

        public void Save(int i)
        {
            PlayerPrefs.SetInt(_key, i);
            PlayerPrefs.Save();
        }

        public int Load()
        {
            return PlayerPrefs.GetInt(_key, 0);
        }
    }
}