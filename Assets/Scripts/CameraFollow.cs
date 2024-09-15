using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;


    private void LateUpdate()
    {
        if (_target)
        {
            Vector3 desiredPos = _target.transform.position + _offset;
            transform.position = desiredPos;
            // transform.LookAt(_target.transform);
        }
    }
}
