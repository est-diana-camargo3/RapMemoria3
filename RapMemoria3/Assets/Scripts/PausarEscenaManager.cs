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
            Time.timeScale = 0f;

            textoPausa.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;

            textoPausa.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}