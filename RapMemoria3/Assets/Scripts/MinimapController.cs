using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public RectTransform playerIcon;

    [Header("Mapa")]
    public Vector2 mapSize = new Vector2(100f, 100f);

    [Header("UI")]
    public RectTransform minimapRect;

    void Update()
    {
        UpdatePlayerIcon();
    }

    void UpdatePlayerIcon()
    {
        // POSICION PLAYER EN MUNDO

        float playerX = player.position.x;
        float playerZ = player.position.z;

        // CONVERTIR A UI

        float normalizedX = playerX / mapSize.x;
        float normalizedZ = playerZ / mapSize.y;

        // TAMAÑO DEL MAPA UI

        float mapWidth = minimapRect.rect.width;
        float mapHeight = minimapRect.rect.height;

        // POSICION FINAL

        float iconX = normalizedX * mapWidth;
        float iconY = normalizedZ * mapHeight;

        playerIcon.anchoredPosition = new Vector2(iconX, iconY);
    }
}
