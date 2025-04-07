using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    void Start()
    {
        StartCoroutine(WaitingLife());
    }


    public void Shoot(float force, Vector3 direction)
{
    _rigidbody.velocity = direction * force;
    StartCoroutine(WaitingLife()); // ← Esto inicia el temporizador cuando se dispara
}
    private IEnumerator WaitingLife()
    {
        yield return new WaitForSeconds(5);
        ProjectilePool.Instance.Return(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            ProjectilePool.Instance.Return(this);
        }
    }

}
