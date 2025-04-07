// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using WeaponSystem;

// public class PauseMenu : MonoBehaviour
// {
//     [SerializeField] private GameObject pauseMenuCanvas;
//     [SerializeField] private GameObject player; // El jugador que necesitas manejar
//     private PlayerMovement playerMovement; // El componente de movimiento del jugador

//     private void Start()
//     {
//         // Obtener el componente PlayerMovement
//         playerMovement = player.GetComponent<PlayerMovement>();
        
//         // Asegúrate de que el Canvas de pausa esté desactivado al inicio
//         if (pauseMenuCanvas != null)
//         {
//             pauseMenuCanvas.SetActive(false); // Desactiva solo el menú de pausa
//         }
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape)) // Cuando presionas Escape
//         {
//             if (pauseMenuCanvas != null)
//             {
//                 bool isActive = pauseMenuCanvas.activeSelf;
//                 pauseMenuCanvas.SetActive(!isActive); // Alterna el estado del Canvas
//                 Time.timeScale = isActive ? 1 : 0; // Pausa o reanuda el juego
//                 if (playerMovement != null)
//                 {
//                     playerMovement.enabled = !isActive; // Desactiva solo el script de movimiento
//                 }
//             }
//         }
//     }

//     public void ResumeGame()
//     {
//         Time.timeScale = 1; // Reanuda el juego
//         pauseMenuCanvas.SetActive(false); // Desactiva el menú de pausa
//         if (playerMovement != null)
//         {
//             playerMovement.enabled = true; // Vuelve a activar el movimiento del jugador
//         }
//     }

//     public void RestartLevel()
//     {
//         Time.timeScale = 1; // Reanuda el juego
//         // Aquí puedes reiniciar el nivel o cargarlo de nuevo
//     }

//     public void GoToMainMenu()
//     {
//         Time.timeScale = 1; // Reanuda el juego
//         // Carga la escena del menú principal
//         SceneManager.LoadScene("MainMenu");
//     }
// }