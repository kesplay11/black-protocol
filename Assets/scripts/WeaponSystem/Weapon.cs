using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _force = 30f;

        [Header("Audio")]
        [SerializeField] private AudioSource shootSound;

        [Header("Balas")]
        [SerializeField] private int totalAmmo = 210;
        [SerializeField] private int magazineSize = 30;
        private int currentAmmo;

        private bool isReloading = false;

        void Start()
        {
            currentAmmo = magazineSize;
        }

        void Update()
        {
            if (isReloading) return;

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }

        private void Shoot()
        {
            if (currentAmmo <= 0)
            {
                Debug.Log("Cargador vacío. Recarga con 'R'");
                return;
            }

            var projectile = ProjectilePool.Instance.Get();
            projectile.transform.position = _spawnPosition.position;
            projectile.gameObject.SetActive(true);
            projectile.Shoot(_force, _spawnPosition.forward);

            shootSound?.Play(); // sonido de disparo (si fue asignado)

            currentAmmo--;
            Debug.Log($"Disparaste. Balas en cargador: {currentAmmo}, Total: {totalAmmo}");
        }

        private IEnumerator Reload()
        {
            if (currentAmmo == magazineSize || totalAmmo <= 0) yield break;

            isReloading = true;
            Debug.Log("Recargando...");

            yield return new WaitForSeconds(1.5f); // tiempo de recarga

            int needed = magazineSize - currentAmmo;
            int toReload = Mathf.Min(needed, totalAmmo);

            currentAmmo += toReload;
            totalAmmo -= toReload;

            Debug.Log($"Recargado. Balas en cargador: {currentAmmo}, Total: {totalAmmo}");

            isReloading = false;
        }
    }
}
