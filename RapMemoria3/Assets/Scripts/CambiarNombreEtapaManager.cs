using UnityEngine;
using TMPro;

public class CambiarNombreEtapaManager : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public TextMeshProUGUI stageText;

    [Header("Audios")]
    public AudioSource etapa1Music;
    public AudioSource etapa2Music;
    public AudioSource etapa3Music;
    public AudioSource etapa4Music;

    [Header("Narracion")]
    public AudioSource narracionDonna;

    private int etapaActual = 0;

    void Update()
    {
        Vector3 pos = player.position;

        // ETAPA 2
        if (pos.x > 0f && pos.x <= 30f &&
            pos.z >= -30f && pos.z <= 0f)
        {
            stageText.text = "Etapa 2: 1971  ->  Manifestaciones en TV";

            CambiarEtapa(2);
        }

        // ETAPA 1
        else if (pos.x >= -30f && pos.x <= 0f &&
                 pos.z >= -30f && pos.z <= 0f)
        {
            stageText.text = "Etapa 1: 1970  ->  El Bronx, AV Sedgwick";

            CambiarEtapa(1);
        }

        // ETAPA 3
        else if (pos.x > 0f && pos.x <= 30f &&
                 pos.z > 0f && pos.z <= 30f)
        {
            stageText.text = "Etapa 3: 1973  ->  DJ Kool Mezclando, Edificio 1520";

            CambiarEtapa(3);
        }

        // ETAPA 4
        else if (pos.x > -30f && pos.x <= 0f &&
                 pos.z >= 0f && pos.z <= 30f)
        {
            stageText.text = "Etapa 4: 1974  ->  MC Coke rapeando en parque";

            CambiarEtapa(4);
        }

        // FUERA DE ZONAS
        else
        {
            stageText.text = "";
        }
    }

    void CambiarEtapa(int nuevaEtapa)
    {
        if (etapaActual == nuevaEtapa)
            return;

        etapaActual = nuevaEtapa;

        // DETENER TODO
        etapa1Music.Stop();
        etapa2Music.Stop();
        etapa3Music.Stop();
        etapa4Music.Stop();
        narracionDonna.Stop();

        // REPRODUCIR SEGUN ETAPA
        switch (nuevaEtapa)
        {
            case 1:
                etapa1Music.Play();
                narracionDonna.Play();
                break;

            case 2:
                etapa2Music.Play();
                break;

            case 3:
                etapa3Music.Play();
                break;

            case 4:
                etapa4Music.Play();
                break;
        }
    }
}