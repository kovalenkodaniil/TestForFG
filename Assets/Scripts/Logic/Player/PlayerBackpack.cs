﻿using UnityEngine;

namespace Logic.Player
{
    public class PlayerBackpack : MonoBehaviour
    {
        [SerializeField] private GameObject[] _items;

        private int _currentItemIndex;

        public void Init()
        {
            _currentItemIndex = 0;

            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].SetActive(false);
            }
        }

        public void TakeItem()
        {
            if (_currentItemIndex == (_items.Length - 1))
                return;

            _currentItemIndex++;
            _items[_currentItemIndex].SetActive(true);
        }

        public void GetItem()
        {
            if (_currentItemIndex <= 0)
                return;

            _items[_currentItemIndex].SetActive(false);
            _currentItemIndex--;
        }
    }
}