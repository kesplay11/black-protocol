using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    //variables de balas, punto de disparo, cantidad de dispados, deteccion del jugador y tag del jugador
    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float fireRate = 1f;      
    public float bulletSpeed = 20f;  
    public float detectionRange = 10f; 
    public LayerMask playerLayer;    

    private Transform player;
    private float nextFireTime = 0f;

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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
}
