using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollide : MonoBehaviour
{
    [SerializeField] bool isLeftSide = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform parentCollider = other.transform.parent;
            float degree = -45.0f;
            if (!isLeftSide)
            {
                degree *= -1;
            }
            parentCollider.GetComponent<PlayerMovement>().switchState(new SwitchLaneState(degree));
        }
    }
}
