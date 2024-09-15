using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MonoBehaviour, IState
{
    public void EnterState(PlayerMovement player)
    {

    }

    public void ExitState(PlayerMovement player)
    {

    }

    public void UpdateState(PlayerMovement player)
    {

        player.Animator.SetInteger("Speed", (int)player.Speed);
        switchLane(player);
        jump(player);
    }

    void switchLane(PlayerMovement player)
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && player.CurrentLanes < 2)
        {
            player.switchState(new SwitchLaneState(45.0f));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.CurrentLanes > 0)
        {
            player.switchState(new SwitchLaneState(-45.0f));
        }
    }

    void jump(PlayerMovement player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.switchState(new JumpState());
        }
    }
}
