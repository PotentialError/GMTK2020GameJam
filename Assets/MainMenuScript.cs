using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject transition;
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
        //Dont have options menu yet. Will Do Later
    }
}
