using UnityEngine;

public class bullet : MonoBehaviour
{
    Light bulletlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletlight.intensity -= 0.2f * (Time.deltaTime); 
    }
}
