using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Player;
using UnityEngine;
using Zenject;

public class IvanFollower : MonoBehaviour
{

    private Vector3 _currentPos;

    [Inject] private PlayerCharacter _playerCharacter;

    [SerializeField]
    private float _zOffset = 25f;

    private void Awake()
    {
        _currentPos = transform.position;
    }

    public void LateUpdate()
    {
        _currentPos.x = transform.position.x;
        _currentPos.y = transform.position.y;
        _currentPos.z = _playerCharacter.transform.position.z + _zOffset;

        transform.position = _currentPos;
    }
}