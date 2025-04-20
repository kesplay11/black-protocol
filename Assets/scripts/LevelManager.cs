using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int enemiesToDefeat = 10; // Número de enemigos a eliminar para pasar de nivel
    private int enemiesDefeated = 0;

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= enemiesToDefeat)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // Carga el siguiente nivel
    }
}