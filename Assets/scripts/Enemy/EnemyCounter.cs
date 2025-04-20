using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class EnemyCounter : MonoBehaviour
{
    //blic int totalEnemies; // Cantidad total de enemigos a matar
    //ivate int currentKills = 0;

    private EnemyMananger enemyMananger;
    private BossHealth bossHealth;

    private BossManager bossManager;

    private bool isBoss = false;
    

    [SerializeField] private TextMeshProUGUI counterText; // Asignalo en el Inspector

    private void Start()
    {
        enemyMananger = EnemyMananger.Instance;
        bossManager = BossManager.Instance;

        isBoss = SceneManager.GetActiveScene().name == "BOSS";
        Debug.Log($"isBoss: {isBoss}");

        if (isBoss){
            GameObject boss = GameObject.FindWithTag("Boss");
            Debug.Log("Jefe Encontrado");
        
            if (boss != null)
            {
                bossHealth = boss.GetComponentInChildren<BossHealth>();
            }
        }


        UpdateCounter();
    }

    /*ublic void RegisterKill(

     {
         currentKills++;
         UpdateCounter();

         if (currentKills >= totalEnemies)
         {
             Debug.Log("¡Nivel completado!");
             // Podés cargar la siguiente escena o mostrar pantalla final
         }
     }*/

    private void Update()
    {
        UpdateCounter();
    }
    private void UpdateCounter()
    {

        if (counterText == null){
            return;
        }
        if (isBoss && bossHealth !=null){
            Debug.Log("Entre aca");

            int life = Mathf.Max(0,bossHealth.enemyLife);
            int lifeMax = bossHealth.enemyLife;
            Debug.Log($"Vida actual del jefe: {life} / {lifeMax}");
            if (life <= 0 ){
                counterText.text = "Jefe Derrotado";
                }
            else{
                counterText.text = $"BOSS : {life} / {lifeMax}";
                }           

         }
        else if (counterText != null && enemyMananger !=null)
            {
            counterText.text = $" {enemyMananger.enemyDead} / {enemyMananger.enemyTotal} ";
            }
    }

}
