using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPath : MonoBehaviour
{
    [SerializeField] private GameObject[] PathPrefabs;
    private int _currentRoad;
    private void Awake()
    {
        _currentRoad = Random.Range(0, PathPrefabs.Length);
        if (_currentRoad == PathPrefabs.Length)
        {
            _currentRoad--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 _currentPosition = gameObject.transform.position;
            GameObject pathMovement = Instantiate(PathPrefabs[_currentRoad], new Vector3(_currentPosition.x, _currentPosition.y, _currentPosition.z + 65.0f), Quaternion.identity, transform.parent.parent);
            pathMovement.name = "Road " + transform.parent.parent.GetComponentInParent<PathSpawner>().roadIndex;
            transform.parent.parent.GetComponentInParent<PathSpawner>().roadIndex++;
            GameManager gm = other.transform.parent.GetComponent<PlayerMovement>().gameManager;
            gm.SpeedPathMovement++;
            pathMovement.GetComponent<PathMovement>().GameManager = gm;

        }
    }
}
