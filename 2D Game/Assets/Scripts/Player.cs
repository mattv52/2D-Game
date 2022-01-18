using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rig;
    public UI ui;
    public Tilemap tileMap;
    
    public float moveSpeed;
    public float jumpForce;
    
    // If collected part, 0=eng, 1=nose, 2=wngs
    public bool[] parts = new bool[3];
    // If collected keys, 0=blue, 1=green, 2=red, 3=yellow
    public bool[] keys = new bool[4];

    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(xInput*moveSpeed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // If fall bellow screen, die
        if (transform.localPosition.y < tileMap.cellBounds.y-3) GameOver();
        
        // Jump logic
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Ensure sprite is facing correct way
        if (rig.velocity.x > 0) sr.flipX = false;
        else if (rig.velocity.x < 0) sr.flipX = true;
    }

    // Function to check if player is on the ground
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    // Triggers gameover and resets the stage
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Adds specific part to player
    public void GetPart(string part)
    {
        switch (part)
        {
            case "engine":
                parts[0] = true;
                break;

            case "nose":
                parts[1] = true;
                break;

            case "wing":
                parts[2] = true;
                break;
        }
    }

    // Adds specific key to player
    public void GetKey(string color)
    {
        switch (color)
        {
            case "blue":
                keys[0] = true;
                ui.addKey(0);
                break;

            case "green":
                keys[1] = true;
                ui.addKey(1);
                break;

            case "red":
                keys[2] = true;
                ui.addKey(2);
                break;

            case "yellow":
                keys[3] = true;
                ui.addKey(3);
                break;
        }
    }

    // Checks player has specific key
    public bool HasKey(string color)
    {
        switch (color)
        {
            case "blue":
                ui.removeKey(0);
                return keys[0];

            case "green":
                ui.removeKey(1);
                return keys[1];

            case "red":
                ui.removeKey(2);
                return keys[2];

            case "yellow":
                ui.removeKey(3);
                return keys[3];
            
            default:
                return false;
        }
    }
}
