using Logic.Zone;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.UI
{
    public class UIActor : MonoBehaviour
    {
        [SerializeField] private List<ButtonViewer> _upgradeDigButton;
        [SerializeField] private List<ButtonViewer> _upgradeDropButton;

        private ButtonViewer _selectedButton;

        public void Init(ZoneEffectDelay digDelay, ZoneEffectDelay dropDelay)
        {
            InitializeButtons(digDelay, _upgradeDigButton);
            InitializeButtons(dropDelay, _upgradeDropButton);
        }

        private void OnDisable()
        {
            ResetButtons(_upgradeDigButton);
            ResetButtons(_upgradeDropButton);
        }

        private void InitializeButtons(ZoneEffectDelay delay, List<ButtonViewer> _buttons)
        {
            foreach (var button in _buttons)
            {
                button.Init(delay);
                button.MultiplicatorSelected += OnMultiplicatorSelected;
            }
        }

        private void ResetButtons(List<ButtonViewer> _buttons)
        {
            foreach (var button in _buttons)
                button.MultiplicatorSelected -= OnMultiplicatorSelected;
        }

        private void OnMultiplicatorSelected(ButtonViewer button) 
        {
            _selectedButton = button;
        }
    }
}
