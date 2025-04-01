using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRespawn : MonoBehaviour
{
    public float timeRespawn = 10f;

    private Vector3 positionSpawn;

    private Quaternion spawnRotation;

    private EnemyHealt resetLife;

    void Start()
    {
        positionSpawn = transform.position;
        spawnRotation = transform.rotation;
        resetLife = GetComponent<EnemyHealt>();

    }

    public void StartRespawn(){
        gameObject.SetActive(false);
        Invoke(nameof(ResetEnemy), timeRespawn);
    }
    void ResetEnemy()
    {
        transform.position = positionSpawn;
        transform.rotation = spawnRotation;
        resetLife.enemyLife = 100;

        gameObject.SetActive(true);
    }

}