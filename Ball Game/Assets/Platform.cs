using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;

    public Rigidbody rb;
    

    public float speed;
    public Vector3 dir;

    void FixedUpdate()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);

        //rb.AddTorque(move * speed);
        float turn = Input.GetAxis("Horizontal");
        rb.AddTorque(platform.transform.forward * speed * turn);
        rb.AddTorque(platform.transform.right * speed * Vertical);


    }
    void Start()
    {
        dir = new Vector3(1, 0, 0);
        rb = GetComponent<Rigidbody>();
        
    }

}
