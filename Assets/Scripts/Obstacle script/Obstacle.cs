using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform parentCollider = other.transform.parent;
            PlayerMovement player = parentCollider.GetComponent<PlayerMovement>();
            player.switchState(new StumbleState());
            player.SoundEffect.PlaySound(audioClip);
            GameManager gm = player.gameManager;
            gm.GameOver();
        }
    }
}
