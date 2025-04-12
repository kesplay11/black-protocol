using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    public Transform baseRotation;
    public float speedRotation = 5f;
    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 direction = player.position - baseRotation.position;
            direction.y = 0f;

            if(direction.sqrMagnitude > 0.1f){
                
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                Quaternion targetRotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
                baseRotation.rotation = Quaternion.Lerp(baseRotation.rotation, targetRotation ,Time.deltaTime * speedRotation);

            }
        }

    }
}
