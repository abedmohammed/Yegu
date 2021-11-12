using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransitions : MonoBehaviour {

    private static MusicTransitions instance;

    public AudioSource bgMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBGM(AudioClip music)
    {
        bgMusic.Stop();
        bgMusic.clip = music;
        bgMusic.Play();
    }
}
