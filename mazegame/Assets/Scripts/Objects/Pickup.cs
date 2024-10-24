using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int value;
    public bool isKey;
    public bool isGem;

    public bool heals;
    public int healAmount;

    [Header("Particles")]
    public GameObject pickUpParticles;

    [Header("SFX")]
    public AudioClip pickUpSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isKey)
            {
                FindObjectOfType<GameManager>().AddKey(value);
                Instantiate(pickUpParticles, transform.position, transform.rotation);
            }

            if(isGem)
            {
                FindObjectOfType<GameManager>().AddGem(value);             
                Instantiate(pickUpParticles, transform.position, transform.rotation);
                AudioManager.audioInstance.sfxAudio.PlayOneShot(pickUpSFX);

            if(heals)

                {
                    FindObjectOfType<Health>().HealPlayer(healAmount);
                }
            }
           
            Destroy(gameObject);
        }
    }
}
