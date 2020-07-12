using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public AudioMixer AudioMixer;
    
    public void BackButton(){
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PauseButton(){
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void AudioSlider(float volume){
        
        AudioMixer.SetFloat("TestVol",Mathf.Log10(volume)*20);
    }
}
