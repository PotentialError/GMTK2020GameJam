﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel(0);
        }
    }
    public void LoadNextLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }
    IEnumerator LoadLevel(int level)
    {
        transition.SetTrigger("EndScene");
        yield return new WaitForSecondsRealtime(3f);
        //SceneManager.LoadScene(level);
    }
}
