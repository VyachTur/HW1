using GameSystem.InterfaceListeners;
using UnityEngine;

public class RunForward : MonoBehaviour, IStartGameListener, IEndGameListener, IPauseGameListener, IRestartGameListener
{
    [SerializeField] private Player.Player _player;
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

    void IStartGameListener.OnStartGame() => 
        enabled = true;

    void IEndGameListener.OnEndGame() => 
        enabled = false;

    void IPauseGameListener.OnPauseGame() => 
        enabled = false;

    void IRestartGameListener.OnRestartGame() => 
        enabled = true;
}
