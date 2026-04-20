using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject menuButtons; // 👈 NUEVO

    public void PlayGame()
    {
        SceneManager.LoadScene("01_Escenario");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        menuButtons.SetActive(false); // 👈 OCULTA BOTONES
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        menuButtons.SetActive(true); // 👈 LOS VUELVE A MOSTRAR
    }
}
