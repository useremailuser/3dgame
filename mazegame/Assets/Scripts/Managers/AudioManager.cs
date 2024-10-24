using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;
    public AudioSource musicAudio;
    public AudioSource sfxAudio;
    [Header("Music Track")]
    public AudioClip music;
    void Awake()
    {
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
            musicAudio.clip = music;
            musicAudio.Play();
        }
    }
}
