using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerLifer = 100;

    public bool isDead = false;

    public void TakeDamange(int damange){
        if(isDead){
            
            return;
        }
        playerLifer-= damange;

        Debug.Log("Player Life: " + playerLifer);

        if(playerLifer <= 0){
           
            Die();
        }


    }

    private void Die(){

        isDead=true;
        Debug.Log("El jugador ah muerto");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
