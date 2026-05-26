using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PausarEscenaManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuPausa;
    public GameObject botonMenu;
    public GameObject minimapUI;
    public GameObject panelInstrucciones;

    [Header("Audio")]
    public Slider masterSlider;
    public Slider vocesSlider;
    public Slider musicaSlider;

    private bool isPaused = false;

    void Start()
    {
        // VALORES INICIALES

        masterSlider.value = 1f;
        vocesSlider.value = 1f;
        musicaSlider.value = 1f;

        // VOLUMEN INICIAL

        AudioListener.volume = 1f;

        // OCULTAR INSTRUCCIONES

        panelInstrucciones.SetActive(false);
    }

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

            // MOSTRAR MENU
            menuPausa.SetActive(true);
            minimapUI.SetActive(false);

            // OCULTAR BOTON MENU
            botonMenu.SetActive(false);

            // LIBERAR CURSOR
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // REANUDAR TIEMPO
            Time.timeScale = 1f;

            // OCULTAR MENU
            menuPausa.SetActive(false);
            minimapUI.SetActive(true);

            // MOSTRAR BOTON MENU
            botonMenu.SetActive(true);

            // OCULTAR INSTRUCCIONES
            panelInstrucciones.SetActive(false);

            // MANTENER CURSOR VISIBLE
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // BOTON VOLVER

    public void Reanudar()
    {
        if (isPaused)
        {
            TogglePause();
        }
    }

    // BOTON REINICIAR

    public void Reiniciar()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("00_MenuInicio");
    }

    // BOTON MENU

    public void AbrirMenu()
    {
        if (!isPaused)
        {
            TogglePause();
        }
    }

    // BOTON INSTRUCCIONES

    public void MostrarInstrucciones()
    {
        // OCULTAR MENU
        menuPausa.SetActive(false);

        // MOSTRAR PANEL
        panelInstrucciones.SetActive(true);

        // INICIAR COROUTINE
        StartCoroutine(CerrarInstrucciones());
    }

    IEnumerator CerrarInstrucciones()
    {
        // ESPERAR 5 SEGUNDOS REALES
        yield return new WaitForSecondsRealtime(5f);

        // OCULTAR PANEL
        panelInstrucciones.SetActive(false);

        // MOSTRAR MENU NUEVAMENTE
        menuPausa.SetActive(true);
    }

    // SLIDERS

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = Mathf.Clamp(volume, 0.05f, 1f);
    }

    public void SetVocesVolume(float volume)
    {
        Debug.Log("Volumen voces: " + volume);
    }

    public void SetMusicaVolume(float volume)
    {
        Debug.Log("Volumen musica: " + volume);
    }
}