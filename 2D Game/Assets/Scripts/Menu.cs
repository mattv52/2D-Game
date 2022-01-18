using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // On play button click, load first level
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    // On exit button click, quit application
    public void OnExitButton()
    {
        Application.Quit();
    }
}
