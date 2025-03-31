using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealt : MonoBehaviour
{

    public int enemyLife = 100;

    public bool destroy= false;

    public int damangeLife;

    private EnemyRespawn respawnScript;

   


    // Start is called before the first frame update
    void Start()
    {
        damangeLife = enemyLife;
        respawnScript = GetComponent<EnemyRespawn>();
        
    }

    public void PruebaAutoDestruccion(){
        if(destroy){
            DestroyEnemy();
        }
    }

    private void DestroyEnemy(){

        if(respawnScript != null){
            destroy = false;
            respawnScript.StartRespawn();
        }

        
    }

    public void PlayerDamange(int Damange){

        if (damangeLife < 0 ){

            respawnScript.StartRespawn();
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        PruebaAutoDestruccion();
    }

}
