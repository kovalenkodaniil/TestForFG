using Logic.Zone;
using TMPro;
using UnityEngine;

namespace Logic.UI
{
    public class DropCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private int count;
        private DropZone _dropZone;

        private void OnDisable()
        {
            _dropZone.ItemDroped -= OnItemDroped;
        }

        public void Init(DropZone dropZone)
        {
            count = 0;
            _dropZone = dropZone;

            _dropZone.ItemDroped += OnItemDroped;
        }

        private void OnItemDroped()
        {
            count++;
            _text.text = count.ToString();
        }
    }
}
