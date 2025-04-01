
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    //variables de balas, punto de disparo, cantidad de dispados, deteccion del jugador y tag del jugador
    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float fireRate = 1f;      
    public float bulletSpeed = 20f;  
    public float detectionRange = 8f; 
    public LayerMask playerLayer;    

    private Transform player;
    private float nextFireTime = 0f;

    private EnemyMovement enemyMovement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Vector3 directionPlayer= (player.position - firePoint.position).normalized;

        float angle = Vector3.Dot(transform.forward, directionPlayer);

        if(angle < 0.0f){
            return;
        }

        float missShoot = 0.1f;

        Vector3 missShootVector = new Vector3(Random.Range(-missShoot, missShoot),
        Random.Range(-missShoot, missShoot),
        Random.Range(-missShoot, missShoot));

        Vector3 shootFinal = (directionPlayer + missShootVector).normalized;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootFinal));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootFinal * bulletSpeed;
    }
}
