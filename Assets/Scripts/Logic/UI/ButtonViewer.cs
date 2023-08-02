using Logic.Zone;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

namespace Logic.UI
{
    public class ButtonViewer: MonoBehaviour
    {
        private const char Symbol = 'X';

        [SerializeField] Button _button;
        [SerializeField] TMP_Text _text;
        [SerializeField] int _multiplicator;
        [SerializeField] Image _buttonImage;
        [SerializeField] Color _targetColor;
        [SerializeField] float _animDuration;

        private ZoneEffectDelay _delay;
        private Vector3 _defaultScale;
        private Color _defualtColor;

        public event UnityAction<ButtonViewer> MultiplicatorSelected;

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

        public void Init(ZoneEffectDelay delay)
        {
            _delay = delay;
            _defaultScale = transform.localScale;
            _defualtColor = _buttonImage.color;
        }

        public void ResetDOTweenAnim()
        {
            _button.interactable = true;

            _button.transform.DOScale(_defaultScale, _animDuration);

            _buttonImage.DOColor(_defualtColor, _animDuration);
        }

        private void OnButtonClicked()
        {
            _delay.SetMultiplication(_multiplicator);

            PlayDoTweenAnim();

            MultiplicatorSelected?.Invoke(this);
        }

        private void PlayDoTweenAnim()
        {
            _button.interactable = false;
            _button.transform.DOScale(new Vector3(1.2f, 1.2f, 1), _animDuration);

            _buttonImage.DOColor(_targetColor, _animDuration);
        }
    }
}
