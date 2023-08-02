using Logic.Zone;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Logic.UI
{
    public class ButtonViewer: MonoBehaviour
    {
        private const char Symbol = 'X';

        [SerializeField] Button _button;
        [SerializeField] TMP_Text _text;
        [SerializeField] int _multiplicator;

        private ZoneEffectDelay _delay;

        public event UnityAction<ButtonViewer> MultiplicatorSelected;

        public void Init(ZoneEffectDelay delay)
        {
            _delay= delay;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void Start()
        {
            _text.text = $"{Symbol} {_multiplicator.ToString()}";
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _delay.SetMultiplication(_multiplicator);

            MultiplicatorSelected?.Invoke(this);
        }
    }
}
