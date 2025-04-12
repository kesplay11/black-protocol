using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour
{

    public Transform cannon;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {  
        
            player = GameObject.FindWithTag("Player")?.transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null || cannon == null){
            return;
        }

        Vector3 direction = player.position - cannon.position;
        Quaternion lookrotation = Quaternion.LookRotation(direction);

        cannon.localRotation= Quaternion.Euler(lookrotation.eulerAngles.x, 0f, 0f);

        
    }
}
