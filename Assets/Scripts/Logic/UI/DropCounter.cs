using Logic.Zone;
using TMPro;
using UnityEngine;

namespace Logic.UI
{
    public class DropCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private DropZone _dropZone;

        private void OnDisable()
        {
            _dropZone.ItemDroped -= OnItemDroped;
        }

        public void Init(DropZone dropZone)
        {
            _dropZone = dropZone;
            _dropZone.ItemDroped += OnItemDroped;
        }

        private void OnItemDroped() =>
            _text.text = _dropZone.DroppedItemsCount.ToString();
    }
}
