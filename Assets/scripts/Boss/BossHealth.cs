using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int enemyLife = 1000;

    public bool destroy= false;


    public void PruebaAutoDestruccion(){
        if(destroy){
            DestroyBoss();
        }
    }

    private void DestroyBoss(){

        Destroy(gameObject);

        
    }

    public void TakeDamange(int Damange){

        enemyLife-= Damange;

        if (enemyLife <= 0 ){
            DestroyBoss();
            BossManager.Instance.EnemyDefeat();

        }
    }
    void Update()
    {
        PruebaAutoDestruccion();
    }

}

