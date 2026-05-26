using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaCargaManager : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(CargarEscenaJuego), 3f);
    }

    void CargarEscenaJuego()
    {
        SceneManager.LoadScene("01_Escenario");
    }
}
