using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private Text starEarnText;
    [SerializeField] private Text scoreEarnTxt;
    [SerializeField] private Text starEarnEndGameText;
    [SerializeField] private Text scoreEarnEndGameText;
    [SerializeField] private GameObject ingameUIHolder;
    [SerializeField] private float _speedPathMovement;
    [SerializeField] GameObject startGameUIHolder;

    private AudioSource audioSource;

    private float speedFactor = 10f;

    private bool isGameOver = false;
    private int coinCollected = 0;
    private float scoreBase = 0f;

    private bool isStartGame = false;

    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public int CoinCollected { get => coinCollected; set => coinCollected = value; }
    public float SpeedPathMovement { get => _speedPathMovement; set => _speedPathMovement = value; }
    public bool IsStartGame { get => isStartGame; set => isStartGame = value; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            speedFactor += Time.deltaTime / 10;
            scoreBase += speedFactor * Time.deltaTime;
            starEarnText.text = coinCollected.ToString();
            scoreEarnTxt.text = ((int)scoreBase).ToString();
        }
    }
    public void GameOver()
    {
        starEarnEndGameText.text = "Star collected: " + starEarnText.text;
        scoreEarnEndGameText.text = "Score gain: " + scoreEarnTxt.text;
        IsGameOver = true;
        StartCoroutine(ShowGameOverPanel());
    }

    public void StartGame(PlayerMovement player)
    {
        IsStartGame = true;
        startGameUIHolder.SetActive(false);
        ingameUIHolder.SetActive(true);
        player.switchState(new RunningState());
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(1.0f);
        _panelGameOver.SetActive(true);

    }
}
