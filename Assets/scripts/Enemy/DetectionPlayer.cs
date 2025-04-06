using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlayer : MonoBehaviour
{
    private EnemyMovement enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponentInParent<EnemyMovement>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){

            Debug.Log("Playter detectado");
            enemyScript.DetectedPlayer(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("player lejos");

            enemyScript.DetectedPlayer(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
