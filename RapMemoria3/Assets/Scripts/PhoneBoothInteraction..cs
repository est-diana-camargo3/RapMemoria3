using UnityEngine;

public class PhoneBoothInteraction : MonoBehaviour
{
    [Header("Panel de informacion")]
    public GameObject infoPanel;

    private void Start()
    {
        infoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoPanel.SetActive(false);
        }
    }
}
