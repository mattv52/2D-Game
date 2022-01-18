using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject fixedRocket;
    public GameObject brokenRocket;
    public Collider2D col;
    // Parts displayed above, 0=eng, 1=nose, 2=wng
    public SpriteRenderer[] parts = new SpriteRenderer[3];


    // Start is called before the first frame update
    void Start()
    {
        // Set rocket to be broken
        fixedRocket.SetActive(false);
    }

    // Checks for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check that collision is with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if player has collected all parts and update rocket accordingly
            bool[] playersParts = collision.gameObject.GetComponent<Player>().parts;
            if (playersParts[0] && playersParts[1] && playersParts[2]) completedRocket();
            if (playersParts[0]) collectedPart("engine");
            if (playersParts[1]) collectedPart("nose");
            if (playersParts[2]) collectedPart("wing");
        }
    }

    // Sets rocket to be completed by enabling and disabling parts
    private void completedRocket()
    {
        fixedRocket.SetActive(true);
        brokenRocket.SetActive(false);
        col.enabled = false;
    }

    // Highlights specific part above the broken rocket
    private void collectedPart(string part)
    {
        switch (part)
        {
            case "engine":
                parts[0].color = Color.white;
                break;

            case "nose":
                parts[1].color = Color.white;
                break;

            case "wing":
                parts[2].color = Color.white;
                break;
        }
    }
}
