using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixedRocket : MonoBehaviour
{
    public bool finalLevel;
    public string nextSceneName;

    // Checks for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check that collision is with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Proced to next level, unless this is final level
            if (finalLevel) SceneManager.LoadScene(0);
            else SceneManager.LoadScene(nextSceneName);
        }
    }
}
