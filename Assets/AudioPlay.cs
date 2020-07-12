using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlay : MonoBehaviour
{
    public AudioSource sound;
    private bool alreadyPlayed;
    private void Start()
    {
        alreadyPlayed = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !alreadyPlayed)
        {
            Debug.Log("PLAY");
            sound.Play();
            StopAllAudio();
            alreadyPlayed = true;
        }
    }
    void StopAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            if(audioS != sound)
            {
                audioS.Stop();
            } 
        }
    }
}
