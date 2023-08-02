using UnityEngine.Events;

namespace Logic.Zone
{
    public class ZoneEffectDelay
    {
        private float _startValue;
        public float Value { get; private set; }

        public event UnityAction DelayChanged;

        public ZoneEffectDelay(float startDelay)
        {
            _startValue = startDelay;
            Value = _startValue;
        }

        public void SetMultiplication(int multiplicator)
        {
            if (multiplicator > 0)
            {
                float newValue = _startValue / multiplicator;

                if (newValue != Value)
                {
                    Value = newValue;
                    DelayChanged?.Invoke();
                }
            }
        }
    }
}
