using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    PlayerMovement playerScript;
    public Transform respawnPoint;
    Collider coll;

    public Animator anim;

    [Header("SFX")]
    public AudioClip gotCheckpointSFX;

    void Start()
    {
        coll = GetComponent<SphereCollider>();
    }
    private void Awake()
    {        
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {   
            playerScript.UpdateCheckpoint(respawnPoint.position);
            coll.enabled = false;
            anim.Play("Checkpoint Achieved");
            AudioManager.audioInstance.sfxAudio.PlayOneShot(gotCheckpointSFX);
            return;        
        }
     
    }

}
