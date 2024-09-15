using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPath : MonoBehaviour
{
    private float _speed;
    private const float OFFSET_TIME = 2.0f;
    private void Awake()
    {
        _speed = transform.parent.GetComponent<PathMovement>().Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyObjectAfterSecond());
        }
    }

    IEnumerator DestroyObjectAfterSecond()
    {
        yield return new WaitForSeconds(_speed + OFFSET_TIME);
        Destroy(transform.parent.gameObject);
    }
}
