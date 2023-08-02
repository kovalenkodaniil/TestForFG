using Logic.Zone;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.UI
{
    public class UIActor : MonoBehaviour
    {
        [SerializeField] private List<ButtonViewer> _upgradeDigButtons;
        [SerializeField] private List<ButtonViewer> _upgradeDropButtons;
        [SerializeField] private DropCounter _counter;

        private ButtonViewer _selectedDigButton;
        private ButtonViewer _selectedDropButton;
        private DropZone _dropZone;

        public void Init(DigZone digZone, DropZone dropZone)
        {
            InitializeButtons(digZone.Delay, _upgradeDigButtons);
            InitializeButtons(dropZone.Delay, _upgradeDropButtons);

            _dropZone = dropZone;
            _dropZone.ItemDroped += OnItemDroped;
        }

        private void OnDisable()
        {
            ResetButtons(_upgradeDigButtons);
            ResetButtons(_upgradeDropButtons);

            _dropZone.ItemDroped -= OnItemDroped;
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

        private void OnItemDroped()
        {
            _counter.AddDrop();
        }
    }
}
