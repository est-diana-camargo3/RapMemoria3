using UnityEngine;
using UnityEngine.InputSystem;

public class PausarEscenaManager : MonoBehaviour
{
    public GameObject textoPausa;

    private bool isPaused = false;

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // PAUSAR TIEMPO
            Time.timeScale = 0f;

            // PAUSAR TODOS LOS AUDIOS
            AudioListener.pause = true;

            // MOSTRAR TEXTO
            textoPausa.SetActive(true);

            // LIBERAR CURSOR
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // REANUDAR TIEMPO
            Time.timeScale = 1f;

            // REANUDAR AUDIOS
            AudioListener.pause = false;

            // OCULTAR TEXTO
            textoPausa.SetActive(false);

            // BLOQUEAR CURSOR
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
