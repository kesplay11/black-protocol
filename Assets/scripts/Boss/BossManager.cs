using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    
    public static BossManager Instance;

    [Header("Boss")]
    public int boss = 1;
    public int bossDead = 0;
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
        bossDead ++;
        Debug.Log("Enemys Dead: " + bossDead);

        if(bossDead >= boss){
            Debug.Log("Level Compleate");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
