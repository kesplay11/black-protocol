using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemies; // Cantidad total de enemigos a matar
    private int currentKills = 0;

    [SerializeField] private TextMeshProUGUI counterText; // Asignalo en el Inspector

    private void Start()
    {
        UpdateCounter();
    }

    public void RegisterKill()
    {
        currentKills++;
        UpdateCounter();

        if (currentKills >= totalEnemies)
        {
            Debug.Log("¡Nivel completado!");
            // Podés cargar la siguiente escena o mostrar pantalla final
        }
    }

    private void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = $"{currentKills} / {totalEnemies}";
    }
}
