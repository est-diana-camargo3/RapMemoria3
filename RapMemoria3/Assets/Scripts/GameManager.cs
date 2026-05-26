using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject menuButtons;

    public void PlayGame()
    {
        // CARGAR PANTALLA DE CARGA
        SceneManager.LoadScene("03_Instrucciones");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        menuButtons.SetActive(true);
    }
}