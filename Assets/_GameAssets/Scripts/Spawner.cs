using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [Range(-0.7f, 0)]
    public float minRange;
    [Range(0, 1.15f)]
    public float maxRange;

    public float tiempoEntreSpawns;
    public GameObject obstaculo;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0, tiempoEntreSpawns);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        float offset = Random.Range(minRange, maxRange);
        Vector3 obstaclePosition = new Vector3(
            transform.position.x,
            transform.position.y + offset,
            transform.position.z);
        Instantiate(obstaculo, obstaclePosition, Quaternion.identity);
    }
}
