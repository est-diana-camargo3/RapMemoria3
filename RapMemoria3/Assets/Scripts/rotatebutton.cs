using UnityEngine;

public class rotatebutton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float speed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.Self);
    }
}
