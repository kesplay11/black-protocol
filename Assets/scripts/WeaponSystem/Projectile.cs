using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifeTime = 5f;

    public int damage = 20;

    private Coroutine _lifeCoroutine;
    private bool _hasHit = false;

    void OnEnable()
    {
        _hasHit = false;
        _rigidbody.velocity = Vector3.zero;
        _lifeCoroutine = StartCoroutine(WaitingLife());
    }

    void OnDisable()
    {
        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
        }
    }

    public void Shoot(float force, Vector3 direction)
{
    _rigidbody.velocity = direction * force;
    StartCoroutine(WaitingLife()); // ← Esto inicia el temporizador cuando se dispara
}
    private IEnumerator WaitingLife()
    {
        yield return new WaitForSeconds(_lifeTime);
        ReturnToPool();
    }

private void OnTriggerEnter(Collider other)
{
    if (_hasHit) return;

    // Ignorar colisiones con zonas auxiliares
    if (other.CompareTag("DetectedZone") || other.CompareTag("Player")) return;

    _hasHit = true;

    if (other.CompareTag("Enemy"))
    {
        
        EnemyHealt enemyHealt = other.GetComponent<EnemyHealt>();
        if (enemyHealt == null)
        {
            enemyHealt = other.GetComponentInParent<EnemyHealt>(); // por si el collider no está en el root
            Debug.Log("me quede aca");
        }

        if (enemyHealt != null)
        {
            enemyHealt.TakeDamange(damage);
        }

        EnemyHealthBoss enemyHealthBoss = other.GetComponent<EnemyHealthBoss>();
        if (enemyHealthBoss == null){
            enemyHealthBoss = other.GetComponentInParent<EnemyHealthBoss>();
        }

        if (enemyHealthBoss != null){

            enemyHealthBoss.TakeDamange(damage);
        }
        
        BossHealth bossHealth = other.GetComponent<BossHealth>();
        if(bossHealth == null){
            bossHealth = other.GetComponentInParent<BossHealth>();
            Debug.Log("Entre al daño del boss");
        }

        if (bossHealth != null){
            
            bossHealth.TakeDamange(damage);
            Debug.Log("En teoria le estoy haciendo daño");
        }
    }

    ReturnToPool();
}

    private void ReturnToPool()
    {
        ProjectilePool.Instance.Return(this);
    }
}

