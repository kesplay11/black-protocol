using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRespawn : MonoBehaviour
{
    public float timeRespawn = 10f;

    private Vector3 positionSpawn;

    private Quaternion spawnRotation;

    void Start()
    {
        positionSpawn = transform.position;
        spawnRotation = transform.rotation;

    }

    public void StartRespawn(){
        gameObject.SetActive(false);
        Invoke(nameof(ResetEnemy), timeRespawn);
    }
    void ResetEnemy()
    {
        transform.position = positionSpawn;
        transform.rotation = spawnRotation;
        gameObject.SetActive(true);
    }

}