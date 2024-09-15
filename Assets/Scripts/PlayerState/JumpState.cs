using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour, IState
{
    public void EnterState(PlayerMovement player)
    {
        player.Rb.AddForce(player.transform.up * player.JumpHeight, ForceMode.Impulse);
        player.Animator.SetTrigger("tgrJump");
    }

    public void ExitState(PlayerMovement player)
    {

    }

    public void UpdateState(PlayerMovement player)
    {

        if (!player.IsGrounded)
        {
            // if wait'til the animation is but still on the air then play falling state
            // the animation is 30 frame = 30 milisecond
            player.startCouroutineCallback(.3f, SwitchStateToFalling);
        }
    }

    private void SwitchStateToFalling(PlayerMovement player)
    {
        player.switchState(new FallingState());
    }
}
