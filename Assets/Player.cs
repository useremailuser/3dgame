using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public GameObject player;

    public float ammo;
    public float health;
    public float moveSpeed = 6;

    private bool hasAmmo;
    private bool isAlive;

    public Transform pivot;
    public Vector3 playerPosition;
    
    Vector3 spawnPoint;
    Vector3 velocity;

    public float sensX;
    public float sensY;

    Rigidbody rigidbody;

    Camera viewCamera;



    //float xRotation
    // float yRotation


    void Start()
    {
        //isAlive = true;
        
        ammo = 6;
        health = 20;
       // spawnPoint = Vector3.playerPosition;

       // Cursor.lockstate = CursorLockMode.Locked;
       // Cursor.visible = false;
       rigidbody = GetComponent<Rigidbody>();
       viewCamera = Camera.main;
  
    }

    void Update()
    {

        //rigidbody = GetComponent<Rigidbody>();
        //if (Input.GetKey(KeyCode.W)) rigidbody.AddForce(Vector3.forward);
        //if (Input.GetKey(KeyCode.S)) rigidbody.AddForce(Vector3.back);
        //if (Input.GetKey(KeyCode.A)) rigidbody.AddForce(Vector3.left);
        //if (Input.GetKey(KeyCode.D)) rigidbody.AddForce(Vector3.right);


        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        rigidbody.velocity = velocity;
   
       

    }
    void FixedUpdate()
    {
       // rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime); 
    }








}