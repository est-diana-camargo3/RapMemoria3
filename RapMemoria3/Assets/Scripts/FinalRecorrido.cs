using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalRecorrido : MonoBehaviour
{
    [Header("Panel Final")]
    public GameObject panelFinal;

    private bool activated = false;

    void Start()
    {
        panelFinal.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;

            panelFinal.SetActive(true);

            Invoke(nameof(VolverMenu), 5f);
        }
    }

    void VolverMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("00_MenuInicio");
    }
}
