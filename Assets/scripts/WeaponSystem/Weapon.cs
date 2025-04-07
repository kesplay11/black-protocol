using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _force = 30f;
        [SerializeField] private float _reloadTime = 2f;

        [SerializeField] private int maxAmmoInClip = 30;
        [SerializeField] private int totalAmmo = 210;

        private int currentAmmoInClip;
        private bool isReloading = false;

        [Header("Audio")]
        [SerializeField] private AudioSource shootAudio;

        // Para acceder desde el HUD si querés más adelante
        public int CurrentAmmo => currentAmmoInClip;
        public int TotalAmmo => totalAmmo;

        void Start()
        {
            currentAmmoInClip = maxAmmoInClip;
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
                if (currentAmmoInClip < maxAmmoInClip && totalAmmo > 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }

        private void Shoot()
        {
            if (currentAmmoInClip <= 0)
            {
                // Podés reproducir un sonido de click vacío si querés
                return;
            }

            currentAmmoInClip--;

            var projectile = ProjectilePool.Instance.Get();
            projectile.transform.position = _spawnPosition.position;
            projectile.gameObject.SetActive(true);
            projectile.Shoot(_force, _spawnPosition.forward);

            if (shootAudio != null)
                shootAudio.Play();
        }

        private IEnumerator Reload()
        {
            isReloading = true;
            yield return new WaitForSeconds(_reloadTime);

            int neededAmmo = maxAmmoInClip - currentAmmoInClip;
            int ammoToReload = Mathf.Min(neededAmmo, totalAmmo);

            currentAmmoInClip += ammoToReload;
            totalAmmo -= ammoToReload;

            isReloading = false;
        }
    }
}