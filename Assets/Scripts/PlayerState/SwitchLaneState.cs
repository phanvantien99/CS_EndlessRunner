using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLaneState : MonoBehaviour, IState
{
    private float degree;
    // the animation have 25 frames = 0.25s
    private const float ANIMATION_FRAME = .25f;
    private bool isRotate = true;
    public SwitchLaneState(float _degree)
    {
        degree = _degree;
    }

    public void EnterState(PlayerMovement player)
    {
        isRotate = false;
        rotateWhileSwitchingLane(player, degree);
    }

    public void ExitState(PlayerMovement player)
    {
        player.DegreeToRotate = 0f;
    }

    public void UpdateState(PlayerMovement player)
    {
    }


    void rotateWhileSwitchingLane(PlayerMovement player, float degree)
    {
        player.DegreeToRotate = degree;
        // if degree to rotate 45 degree then next lane is right side
        if (degree > 0)
        {
            player.CurrentLanes++;
        }
        else if (degree < 0)
        {
            player.CurrentLanes--;
        }
        if (!isRotate)
        {
            player.Animator.SetBool("isSwitchingLane", true);
            player.startCouroutineCallback(ANIMATION_FRAME, switchStateToRunning);
        }
    }

    public void switchStateToRunning(PlayerMovement player)
    {
        player.switchState(new RunningState());
        player.Animator.SetBool("isSwitchingLane", false);
    }
}
