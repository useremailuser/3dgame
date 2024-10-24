using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private int value;
    private bool opened;
    public Animator anim;

    public GameManager keys;

    [Header("SFX")]
    public AudioClip openSFX;

    // Start is called before the first frame update
    void Start()
    {
        value = -1;
        opened = false;
        keys = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !opened && keys.currentKeys > 0)
        {
            opened = true;
            FindObjectOfType<GameManager>().TakeKey(value);
            anim.Play("Door Open");
            AudioManager.audioInstance.sfxAudio.PlayOneShot(openSFX);

        }
    }
}
