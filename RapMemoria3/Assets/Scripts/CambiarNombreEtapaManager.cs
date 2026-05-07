using UnityEngine;
using TMPro;

public class CambiarNombreEtapaManager : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public TextMeshProUGUI stageText;

    void Update()
    {
        Vector3 pos = player.position;

        // ETAPA 2
        if (pos.x >= 29f && pos.x <= 60f &&
            pos.z >= -30f && pos.z <= 0f)
        {
            stageText.text = "ETAPA 2: 1971 - Manifestaciones en TV";
        }

        // ETAPA 1
        else if (pos.x >= -3f && pos.x <= 28.9f &&
                 pos.z >= -30f && pos.z <= 0f)
        {
            stageText.text = "ETAPA 1: 1970 - El Bronx, AV Sedgwick";
        }

        // ETAPA 3
        else if (pos.x >= 29f && pos.x <= 60f &&
                 pos.z >= 0.1f && pos.z <= 30f)
        {
            stageText.text = "ETAPA 3: 1973 - DJ Kool mezclando";
        }

        // ETAPA 4
        else if (pos.x >= -3f && pos.x <= 28.9f &&
                 pos.z >= 0.1f && pos.z <= 30f)
        {
            stageText.text = "ETAPA 4: 1974 - MC Coke rapeando";
        }

        // FUERA DE ZONAS
        else
        {
            stageText.text = "";
        }
    }
}
