using Logic.Zone;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.UI
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private List<ButtonViewer> _upgradeDigButtons;
        [SerializeField] private List<ButtonViewer> _upgradeDropButtons;
        [SerializeField] private DropCounter _counter;

        private ButtonViewer _selectedDigButton;
        private ButtonViewer _selectedDropButton;

        public void Init(ZoneEffectDelay digDelay, ZoneEffectDelay dropZone)
        {
            InitializeButtons(digDelay, _upgradeDigButtons);
            InitializeButtons(dropZone, _upgradeDropButtons);
        }

        private void OnDisable()
        {
            ResetButtons(_upgradeDigButtons);
            ResetButtons(_upgradeDropButtons);
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
            if (_upgradeDigButtons.Contains(button))
            {
                _selectedDigButton?.ResetDOTweenAnim();

                _selectedDigButton = button;
            }
            else
            {
                _selectedDropButton?.ResetDOTweenAnim();

                _selectedDropButton = button;
            }
        }
    }
}
