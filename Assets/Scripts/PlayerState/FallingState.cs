using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : MonoBehaviour, IState
{
    public void EnterState(PlayerMovement player)
    {
        player.Animator.SetBool("isGrounded", false);
    }

    public void ExitState(PlayerMovement player)
    {
        player.Animator.SetBool("isGrounded", true);

    }

    public void UpdateState(PlayerMovement player)
    {

        if (player.IsGrounded)
        {
            player.switchState(new RunningState());
        }
    }

}
