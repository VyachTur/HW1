using System;
using Player;
using UnityEngine;

public class RunForward : MonoBehaviour
{
    [SerializeField] private PlayerObject _player;
    [SerializeField] private float _speed = 10f;

    private Rigidbody _playerRB;

    private void Awake()
    {
        _playerRB = _player.GetComponent<Rigidbody>();
        enabled = false;
    }

    private void Start() => 
        MoveForward();

    private void MoveForward() => 
        _playerRB.velocity = Vector3.forward * _speed;
}
