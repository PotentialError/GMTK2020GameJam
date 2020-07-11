using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    public GameObject transition;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public AudioMixer AudioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton(){
        transition.GetComponent<SceneTransition>().LoadNextLevel(1);
    }
    public void OptionsButton(){
       mainMenu.SetActive(false);
       optionsMenu.SetActive(true);
    }
    public void BackButton(){
        mainMenu.SetActive(true);
       optionsMenu.SetActive(false);
    }
    public void AudioSlider(float volume){
        
        AudioMixer.SetFloat("MasterVol",Mathf.Log10(volume)*20);
    }
}
