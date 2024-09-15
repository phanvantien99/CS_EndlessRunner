using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    private float _speed;
    private GameManager _gameManager;

    public float Speed { get => _speed; set => _speed = value; }
    public GameManager GameManager { get => _gameManager; set => _gameManager = value; }

    private void Update()
    {
        _speed = GameManager.SpeedPathMovement;

    }
    private void LateUpdate()
    {
        if (!GameManager.IsGameOver && GameManager.IsStartGame)
            gameObject.transform.Translate(Vector3.forward * _speed * Time.deltaTime * -1.0f);
    }
}
