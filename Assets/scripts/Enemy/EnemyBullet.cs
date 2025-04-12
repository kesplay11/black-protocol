using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int damageBullet = 20;  
    public float lifeTimeBullet = 5f;  

    void Start()
    {
        Destroy(gameObject, lifeTimeBullet);  
    }

    //si impacta al jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageBullet);
            }
        }

        Destroy(gameObject); 
    }
}


