using UnityEngine;

public class CameraReal : MonoBehaviour
{

    Camera viewCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousPos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.LookAt(mousPos + Vector3.up * transform.position.y);
    }
}
