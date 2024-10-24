using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Stats")]
    
    public float moveSpeed;
    public float jumpHeight;
    public float gravityScale;

    

    private bool canDJump;
    private bool isJumping; 
    private bool isDJumping;

    private bool isAlive;

    [Header("Nerd Stuff")]
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerObject;
    public GameObject playerModel;
    public Animator anim;

    private CharacterController controller;

    public Vector3 moveDirection;

    public Health health;

    public float invincibilityLength;
    private float invincibilityCounter;

    Vector3 respawnPos;

    //public AudioSource audioSource;

    [Header("SFX")]
    public AudioClip jumpSFX;
    public AudioClip doubleJumpSFX;
    public AudioClip hurtSFX;
    public AudioClip deathSFX;

    [Header("Particles")]
    public GameObject doubleJumpParticles;
    public GameObject hurtParticles;
    public GameObject deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        controller = GetComponent<CharacterController>();
        respawnPos = gameObject.transform.position;
        //audioSource = GetComponent<AudioSource>();

        //health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update() 
    {     
        //Moving
        if(isAlive)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        }
        else
        {
            moveDirection = new Vector3(0, 0, 0);
               
        }
        
        if(controller.isGrounded)
        {
            isJumping = false;

            //Are we still or are we moving?
            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                anim.Play("Idle");
            }
            else
            {
                anim.Play("Moving");
            }
                
            //Jumping
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpHeight;
                isJumping = true;
                AudioManager.audioInstance.sfxAudio.PlayOneShot(jumpSFX);
            }

            canDJump = false;
            isDJumping = false;
        }

        //Character rotation
        if((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && isAlive)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));    
            playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, newRotation, rotateSpeed *  Time.deltaTime);
        }

        //Applying gravity
        if(!controller.isGrounded && isAlive) 
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            canDJump = true;

            //What's happening in the air?
            if(invincibilityCounter <= 0)
            {
                if (!isDJumping)
                {
                    if (isJumping)
                    {
                        anim.Play("Jumping");
                    }
                    else
                    {
                        anim.Play("Falling");
                    }

                }
                else
                {
                    anim.Play("DJumping");

                }
            }
         
            //Double jumping
            if (Input.GetButtonDown("Jump") && canDJump && !isDJumping)
            {
                moveDirection.y = jumpHeight;
                isDJumping = true;
                AudioManager.audioInstance.sfxAudio.PlayOneShot(doubleJumpSFX);
                Instantiate(doubleJumpParticles, transform.position, transform.rotation);
            }
        }

        //Invincibility frames
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }

        //Dying lol
        if (health.remainingHealth <= 0 && isAlive)
        {
            StartCoroutine(Death());
        }

        controller.Move(moveDirection * Time.deltaTime);
   
    }
    //Checkpoints
    public void UpdateCheckpoint(Vector3 pos)
    {
        respawnPos = pos;
    }

    //Colliding with enemy
    private void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Hazard") && invincibilityCounter <= 0) && isAlive)
        {
            moveDirection.y = 5;
            FindObjectOfType<Health>().HurtPlayer(1);      
            AudioManager.audioInstance.sfxAudio.PlayOneShot(deathSFX);
            invincibilityCounter = invincibilityLength;
            anim.Play("Hurt");
            Instantiate(hurtParticles, transform.position, transform.rotation);

        }
        if ((other.CompareTag("Death") && isAlive))
        {
            FindObjectOfType<Health>().HurtPlayer(3);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Spring")))
        { 
            canDJump = true;
            isDJumping = false;
        }

        if ((other.CompareTag("Goal")))
        {
            isAlive = false;
        }
    }


    IEnumerator Death()
    {
        Debug.Log("Dead");
        anim.Play("Death");
        isAlive = false;
        Instantiate(deathParticles, transform.position, transform.rotation);
        //playerModel.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = respawnPos;
        //playerModel.SetActive(true);   
        health.remainingHealth = health.numOfHearts;
        yield return new WaitForSeconds(0.1f);
        isAlive = true;

    }
}
