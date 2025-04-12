using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerLifer;
    public bool isDead = false;

    [SerializeField] private Slider lifeBar;

    private void Start()
    {
        playerLifer = maxHealth;

        if (lifeBar != null)
        {
            lifeBar.maxValue = maxHealth;
            lifeBar.value = playerLifer;
            lifeBar.interactable = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        playerLifer -= damage;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }     
}