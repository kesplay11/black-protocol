using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{

    public int enemyLife = 100;

    public int damangeLife;
    // Start is called before the first frame update
    void Start()
    {
        damangeLife = enemyLife;
    }

    public void playerDamange(int Damange){

        if (damangeLife < 0 ){
            Destroy(gameObject);
        }
    }
    
}
