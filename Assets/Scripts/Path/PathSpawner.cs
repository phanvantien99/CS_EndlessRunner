using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _initPrefabs;

    public int roadIndex = 1;
    private void Start()
    {
        GameObject road = Instantiate(_initPrefabs, this.transform.position, Quaternion.identity, transform);
        road.name = "Road " + roadIndex;
        roadIndex++;
        road.GetComponent<PathMovement>().GameManager = _gameManager;
        road.SetActive(true);
    }

}
