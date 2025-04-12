using UnityEngine;


public class EnemyHealt : MonoBehaviour
{

    public int enemyLife = 100;

    public bool destroy= false;

    private EnemyRespawn respawnScript;

   


    // Start is called before the first frame update
    void Start()
    {
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

    public void TakeDamange(int Damange){

        enemyLife-= Damange;

        if (enemyLife <= 0 ){

            respawnScript.StartRespawn();

        }
    }
    void Update()
    {
        PruebaAutoDestruccion();
    }

}
