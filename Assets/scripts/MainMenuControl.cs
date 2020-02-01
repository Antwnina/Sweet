﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour {

public void PlayGame()
    {
        
        SceneManager.LoadScene("Chocolate");
    }

public void QuitGame()
    {
        Application.Quit();
    }

public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
