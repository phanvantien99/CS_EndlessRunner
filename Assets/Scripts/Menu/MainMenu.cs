using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] PlayerMovement player;
    public void PlayGame()
    {
        _gameManager.StartGame(player);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
