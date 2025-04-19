using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBoss : MonoBehaviour
{
    public int enemyLife = 100;

    public bool destroy= false;

    private EnemyRespawnBoss enemyRespawnScript;

   


    // Start is called before the first frame update
    void Start()
    {
        enemyRespawnScript = GetComponent<EnemyRespawnBoss>();
        
    }

    public void PruebaAutoDestruccion(){
        if(destroy){
            DestroyEnemy();
        }
    }

    private void DestroyEnemy(){

        if(enemyRespawnScript != null){
            destroy = false;
            enemyRespawnScript.StartRespawn();
        }

        
    }

    public void TakeDamange(int Damange){

        enemyLife-= Damange;

        if (enemyLife <= 0 ){

            enemyRespawnScript.StartRespawn();

        }
    }
    void Update()
    {
        PruebaAutoDestruccion();
    }

}
