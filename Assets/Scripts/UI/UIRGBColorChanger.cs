using Savers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Changes RGB values of target's spriteRenderer.Color via sliders
    /// </summary>
    public class UIRGBColorChanger : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _target;

        [SerializeField]
        private Slider _sliderRed;
        [SerializeField]
        private Slider _sliderGreen;
        [SerializeField]
        private Slider _sliderBlue;

        private ISaver<string> _saver;
        const string saverKey = "BallColor";


        private void Awake()
        {
            if (_target == null)
            {
                Debug.LogError($"No target assigned for {this.name}", this);
                gameObject.SetActive(false);
                return;
            }

            _saver = new PlayerPrefsStringSaver(saverKey);

            TryLoad();
            InitSliders();            
        }


        private void InitSliders()
        {
            _sliderRed.value = _target.color[0];
            _sliderGreen.value = _target.color[1];
            _sliderBlue.value = _target.color[2];

            _sliderRed.onValueChanged.AddListener(ValueChangedRed);
            _sliderGreen.onValueChanged.AddListener(ValueChangedGreen);
            _sliderBlue.onValueChanged.AddListener(ValueChangedBlue);
            

            void ValueChangedRed(float value)
            {
                ValueChanged(value, 0);
            }

            void ValueChangedGreen(float value)
            {
                ValueChanged(value, 1);
            }

            void ValueChangedBlue(float value)
            {
                ValueChanged(value, 2);
            }


            void ValueChanged(float value, int index)
            {
                var color = _target.color;
                color[index] = value;
                _target.color = color;
            }
        }

        private void TrySave()
        {
            var str = ColorUtility.ToHtmlStringRGB(_target.color);
            _saver.Save(str);            
        }

        private void TryLoad()
        {
            var str = '#' + _saver.Load();
            if (ColorUtility.TryParseHtmlString(str, out var color))
                _target.color = color;
        }


        private void OnApplicationQuit()
        {
            TrySave();
        }
    }
}