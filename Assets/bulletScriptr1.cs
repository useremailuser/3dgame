using UnityEngine;

public class bulletScriptr1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
           Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 8)
        {
          
        }
        

    }
}
