using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 startPosition;

    public float moveSpeed;
    private bool movingToTarget;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        movingToTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Logic for moving between 2 points
        if(movingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition) movingToTarget = false;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (transform.position == startPosition) movingToTarget = true;
        }
    }

    // Check for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision is with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
