using UnityEngine;

namespace Savers
{
    public class PlayerPrefsStringSaver : ISaver<string>
    {
        protected string _key;

        public PlayerPrefsStringSaver(string key)
        {
            _key = key;
        }

        public void Save(string str)
        {
            PlayerPrefs.SetString(_key, str);
            PlayerPrefs.Save();
        }

        public string Load()
        {
            return PlayerPrefs.GetString(_key, "");
        }
    }
}