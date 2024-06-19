using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    [Header("---- Music ----")]
    public AudioClip backgroundMusic;
    public AudioClip battleMusic;

    // [Header("---- Music ----")]
    // public 

    private void Start()
    {
        this.music.clip = backgroundMusic;
        this.music.Play();
    }

    private void Update()
    { 
        if (FindObjectOfType<BattleManager>().IsInCombat() && this.music.clip == backgroundMusic)
        {
            this.music.clip = battleMusic;
            this.music.Play();
        }
        else if (!FindObjectOfType<BattleManager>().IsInCombat() && this.music.clip == battleMusic)
        {
            this.music.clip = backgroundMusic;
            this.music.Play();
        }
    }
}
