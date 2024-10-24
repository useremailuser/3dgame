using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownSpring : MonoBehaviour
{
    public float springHeight;
    public Animator anim;
    PlayerMovement player;

    [Header("Particles")]
    public GameObject springParticles;

    [Header("SFX")]
    public AudioClip bounceSFX;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.Play("Spring Bounce");
            AudioManager.audioInstance.sfxAudio.PlayOneShot(bounceSFX);
            player.moveDirection.y = springHeight;
            Instantiate(springParticles, transform.position, transform.rotation);

        }
    }
}
