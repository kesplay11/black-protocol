using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public int damage = 20;

    void Start()
    {
        StartCoroutine(WaitingLife());
    }


    public void Shoot(float force, Vector3 direction)
    {
        _rigidbody.velocity = direction * force;
    }

    private IEnumerator WaitingLife()
    {
        yield return new WaitForSeconds(5);
        ProjectilePool.Instance.Return(this);
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Enemy")){
            EnemyHealt enemyHealt = other.GetComponent<EnemyHealt>();

            if(enemyHealt != null){
                enemyHealt.TakeDamange(damage);
            }
            ProjectilePool.Instance.Return(this);
        }
        if (other.CompareTag("Environment"))
        {
            ProjectilePool.Instance.Return(this);
        }
        
    }

}
