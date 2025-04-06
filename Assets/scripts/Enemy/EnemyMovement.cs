
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;         
    public Transform targetPlayer;                 
    public float patrolWaitTime = 2f;       

    private Animator animator; 

    private NavMeshAgent agent;
    private int currentPatrolIndex;
    private bool followPlayer = false;
    private float waitTimer;
    
    


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetInteger("status_MP40",1);
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (followPlayer && targetPlayer !=null )
        {
            agent.SetDestination(targetPlayer.position);

        }
        
        else
        {
            Patrol();
        }

        if(agent.remainingDistance > agent.stoppingDistance){
                animator.SetInteger("Status_walk",1);
            }  else{
                animator.SetInteger("Status_walk",0);
            }

    }

    void Patrol()
    {
        if (agent.remainingDistance < 2f && !agent.pathPending)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= patrolWaitTime)
            {
                GoToNextPatrolPoint();
                waitTimer = 0f;
                
            }

        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    
    public void DetectedPlayer(bool detected){

        followPlayer = detected;

        if(followPlayer){

            agent.SetDestination(targetPlayer.position);
        }else{

            GoToNextPatrolPoint();
        }
    }
    
}
