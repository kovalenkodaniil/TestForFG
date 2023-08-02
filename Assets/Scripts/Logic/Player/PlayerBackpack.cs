using System;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerBackpack : MonoBehaviour
    {
        [SerializeField] private GameObject[] _items;

        private int _currentItemIndex;
        private bool _isFull;
        private bool _isEmpty;

        public void Init()
        {
            _currentItemIndex = 0;
            _isEmpty = true;
            _isFull = false;

            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].SetActive(false);
            }
        }

        public void TakeItem()
        {
            if (_isFull)
                return;

            _isEmpty = false;

            _items[_currentItemIndex].SetActive(true);
            _currentItemIndex++;

            if (_currentItemIndex >= _items.Length)
            {
                _currentItemIndex = _items.Length - 1;
                _isFull = true;
            }
        }

        public void GetItem(Action onGeted = null)
        {
            if (_isEmpty)
                return;

            _isFull = false;

            _items[_currentItemIndex].SetActive(false);
            _currentItemIndex--;

            onGeted?.Invoke();

            if (_currentItemIndex < 0)
            {
                _currentItemIndex = 0;
                _isEmpty = true;
            }
        }
    }
}
