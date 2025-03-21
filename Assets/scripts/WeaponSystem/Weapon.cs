using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _force = 30;

        // Update is called once per frame
        void Update()
        {
            // Solo disparamos si se hace clic izquierdo (Button 0).
            if (Input.GetMouseButtonDown(0)) 
            {
                Shoot(); // Llamamos a la función para disparar solo cuando se hace clic.
            }
        }

        private void Shoot()
        {
            // Obtiene un proyectil de la piscina.
            var projectile = ProjectilePool.Instance.Get();

            // Establece la posición del proyectil en el punto de disparo.
            projectile.transform.position = _spawnPosition.position;

            // Activa el proyectil.
            projectile.gameObject.SetActive(true);

            // Llama al método Shoot() del proyectil para darle fuerza y dirección.
            projectile.Shoot(_force, _spawnPosition.forward);
        }
    }
}