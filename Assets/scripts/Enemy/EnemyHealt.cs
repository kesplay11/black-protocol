using UnityEngine;


public class EnemyHealt : MonoBehaviour
{

    public int enemyLife = 100;

    public bool destroy= false;

    private EnemyRespawn respawnScript;

   
    private EnemyCounter enemyCounter; 

     private bool alreadyCounted = false; // ← Para evitar contar varias veces



    // Start is called before the first frame update
    void Start()
    {
        respawnScript = GetComponent<EnemyRespawn>();
        enemyCounter = FindObjectOfType<EnemyCounter>(); // ← Esto busca el objeto que tenga ese script
        
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
        if (enemyLife <= 0 && !alreadyCounted){

            alreadyCounted = true;

            if(enemyCounter != null)
            {
                enemyCounter.RegisterKill();
            }

            if(respawnScript != null)
            {
                respawnScript.StartRespawn();
            }


        }
    }
    }
    void Update()
    {
        PruebaAutoDestruccion();
    }
}
