using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMananger : MonoBehaviour
{
    public static EnemyMananger Instance;

    [Header("LEVEL1")]
    public int enemyTotal = 10;
    public int enemyDead = 0;

    [Header("LEVEL2")]

    public string nextLevel;

    void Awake()
    {
        if (Instance == null){
            Instance= this;
        }else{
            Destroy(gameObject);
        }
    }

    public void EnemyDefeat(){
        enemyDead ++;
        Debug.Log("Enemys Dead: " + enemyDead);

        if(enemyDead >= enemyTotal){
            Debug.Log("Level Compleate");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
