using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumbleState : MonoBehaviour, IState
{
    public void EnterState(PlayerMovement player)
    {
        player.Animator.SetTrigger("tgrStumble");
        player.Collider.height = 0f;
    }

    public void ExitState(PlayerMovement player)
    {
        // do nothing
    }

    public void UpdateState(PlayerMovement player)
    {
        // do nothing
    }
}
