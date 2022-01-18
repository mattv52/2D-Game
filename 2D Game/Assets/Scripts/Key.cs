using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyColor;

    // Checks for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check that collision is with player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add key to player and remove it
            collision.gameObject.GetComponent<Player>().GetKey(keyColor);
            Destroy(gameObject);
        }
    }
}
