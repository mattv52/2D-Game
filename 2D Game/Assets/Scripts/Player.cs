using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    // If collected part, 0=eng, 1=nose, 2=wngs
    public bool[] parts = new bool[3];
    // If collected keys, 0=blue, 1=green, 2=red, 3=yellow
    public bool[] keys = new bool[4];
    public UI ui;
    public Tilemap tileMap;

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
                break;

            case "green":
                keys[1] = true;
                break;

            case "red":
                keys[2] = true;
                break;

            case "yellow":
                keys[3] = true;
                break;
        }
    }

    // Checks player has specific key
    public bool HasKey(string color)
    {
        switch (color)
        {
            case "blue":
                return keys[0];

            case "green":
                return keys[1];

            case "red":
                return keys[2];

            case "yellow":
                return keys[3];
            
            default:
                return false;
        }
    }
}
