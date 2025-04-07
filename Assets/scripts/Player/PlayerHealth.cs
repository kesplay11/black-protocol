using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxLife = 100;
    public int playerLifer;
    public bool isDead = false;

    [SerializeField] private Slider lifeBar; // Asigna desde el Inspector

    private void Start()
    {
        // Inicializamos el valor de la barra
        playerLifer = maxHealth;

        if (lifeBar != null)
        {
            lifeBar.maxValue = maxLife;
            lifeBar.value = playerLifer;
            lifeBar.interactable = false; // No interactuable
        }
    }

    public void TakeDamange(int damange)
    {
        if (isDead)
            return;

        playerLifer -= damange;
        Debug.Log("Player Life: " + playerLifer);

        if (lifeBar != null)
        {
            lifeBar.value = playerLifer;
        }

        if (playerLifer <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("El jugador ha muerto");

        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}