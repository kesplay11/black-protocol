using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Asegúrate de que el nombre coincide con tu escena
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego..."); // Solo se ve en el Editor, no en la build final
    }
}
