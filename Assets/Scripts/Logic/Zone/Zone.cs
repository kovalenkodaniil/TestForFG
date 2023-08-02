using Logic.Player;
using System.Collections;
using UnityEngine;

namespace Logic.Zone
{
    public abstract class Zone : MonoBehaviour
    {
        [SerializeField] private EnterTrigger _triger;
        [SerializeField] private float _startDelay;

        private ZoneEffectDelay _delay;
        private Coroutine _currentCorotine;
        private PlayerBackpack _player;
        private float _currentDelay;

        public ZoneEffectDelay Delay => _delay;

        public void Init()
        {
            _delay = new ZoneEffectDelay(_startDelay);

            _delay.DelayChanged += OnDelayChanged;
        }

        private void OnEnable()
        {
            _triger.PlayerEntered += OnPlayerEntered;
            _triger.PlayerExited += OnPlayerExited;
        }

        private void OnDisable()
        {
            _triger.PlayerEntered -= OnPlayerEntered;
            _triger.PlayerExited -= OnPlayerExited;
            _delay.DelayChanged -= OnDelayChanged;
        }

        private  void OnPlayerEntered(PlayerBackpack player)
        {
            _player = player;
            RunCoroutine();
        }

        private void OnDelayChanged()
        {
            if (_currentDelay < _delay.Value)
            {
                if (_currentCorotine != null)
                {
                    StopCoroutine(_currentCorotine);
                    RunCoroutine();
                }
            }
            else
            {
                StopCoroutine(_currentCorotine);
                ChangeBackpackValue(_player);
            }
        }

        private void OnPlayerExited()
        {
            StopCoroutine(_currentCorotine);
        }

        private IEnumerator WaitDelay(float delay)
        {
            _currentDelay = delay;
            float currentTime = delay;

            while (currentTime > 0) 
            {
                currentTime -= Time.deltaTime;
                yield return null;
            }

            ChangeBackpackValue(_player);
        }

        private void RunCoroutine() =>
            _currentCorotine = StartCoroutine(WaitDelay(_delay.Value));

        protected virtual void ChangeBackpackValue(PlayerBackpack player)
        {
            RunCoroutine();
        }
    }
}
