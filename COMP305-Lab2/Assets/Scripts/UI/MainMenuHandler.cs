using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//new using statement
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public void Play()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene("Week6_2");

    }

    public void Quit()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
