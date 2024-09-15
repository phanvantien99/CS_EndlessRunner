using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] AudioClip audioClip;
    private void Start()
    {
        transform.DORotate(new Vector3(0f, 360.0f, 0f), 3f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        GameManager gm = transform.parent.parent.GetComponent<GameManager>();
        if (gm)
            _gameManager = gm;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerMovement player = other.transform.parent.GetComponent<PlayerMovement>();
            GameManager gm = player.gameManager;
            gm.CoinCollected++;
            player.SoundEffect.PlaySound(audioClip);
            Destroy(gameObject);
        }
    }
}
