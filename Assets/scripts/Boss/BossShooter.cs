using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 30f;
    public float detectionRange = 20f;
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
            ShootAtPlayer();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootAtPlayer()
    {

        Vector3 directionPlayer= (player.position - firePoint.position).normalized;

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

