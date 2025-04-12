using UnityEngine;

public class EnemyRespawnBoss : MonoBehaviour
{
    public float timeRespawn = 10f;

    private Vector3 positionSpawn;

    private Quaternion spawnRotation;

    private EnemyHealthBoss resetLife;

    void Start()
    {
        positionSpawn = transform.position;
        spawnRotation = transform.rotation;
        resetLife = GetComponent<EnemyHealthBoss>();

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
