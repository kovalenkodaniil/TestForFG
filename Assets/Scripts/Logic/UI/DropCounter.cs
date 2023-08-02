using TMPro;
using UnityEngine;

namespace Logic.UI
{
    public class DropCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private int count;

        public void AddDrop()
        {
            count++;

            _text.text = count.ToString();
        }
    }
}
