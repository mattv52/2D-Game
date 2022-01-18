using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string part;

    //Checks for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision is with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add part to player and remove it
            collision.gameObject.GetComponent<Player>().GetPart(part);
            Destroy(gameObject);
        }
    }

}
