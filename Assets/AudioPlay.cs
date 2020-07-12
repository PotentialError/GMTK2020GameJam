using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audio;
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
            audio.Play();
            //play();
            StopAllAudio();
            alreadyPlayed = true;
        }
    }
    void StopAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            if(audioS != audio)
            {
                audioS.Stop();
            }

        }
    }
    IEnumerator play()
    {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        //Destroy(this.gameObject);
    }
}
