using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public string keyColor;

    // Checks for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check that collision is with player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check that player has appropriate key
            if (collision.gameObject.GetComponent<Player>().HasKey(keyColor))
            {
                Destroy(gameObject);
            }
        }
    }
}
