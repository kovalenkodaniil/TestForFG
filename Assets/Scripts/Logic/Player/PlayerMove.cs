using Infrastructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private InputService _inputService;

    public void Init(InputService inputService)
    {
        _inputService = inputService;
    }

    private void Update()
    {
        if (_inputService == null)
            return;

        transform.position += _inputService.Direction * Time.deltaTime * _speed;
    }
}
