using UnityEngine;
using UnityEngine.UI;
using TMPro; // Solo si usás TextMeshPro

public class PlayerUI : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerHealth playerHealth;

    [Header("Munición")]
    [SerializeField] private TextMeshProUGUI ammoText; // O `Text` si no usás TMP
    [SerializeField] private WeaponSystem.Weapon weapon;

    void Update()
    {
        if (playerHealth != null)
        {
            healthBar.maxValue = playerHealth.maxHealth;
            healthBar.value = playerHealth.playerLifer;
        }

        if (weapon != null)
        {
            ammoText.text = $"{weapon.CurrentAmmo} / {weapon.TotalAmmo}";
        }
    }
}

