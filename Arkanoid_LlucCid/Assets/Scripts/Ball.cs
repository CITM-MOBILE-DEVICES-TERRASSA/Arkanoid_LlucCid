using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private float minVerticalVelocity = 1f;

    public Rigidbody2D ballRb;
    private bool isBallMoving;

    Vector2 startposition;
    void Start()
    {
        startposition = transform.position;
        ballRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            Launch();
        }
    }

    private void Launch()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
        isBallMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Dead Zone")) {
            FindObjectOfType<GameManager>().LoseHealth();
        }*/

        if (collision.gameObject.CompareTag("Block"))
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                int previousLives = block.lives;  // Guarda las vidas antes de llamar a Hit
                block.Hit();

                // Solo aumenta la velocidad si el bloque fue destruido
                if (previousLives > 0 && block.lives <= 0)
                {
                    ballRb.velocity *= velocityMultiplier;
                    LimitVelocity();
                }
            }
        }

        // Asegura una velocidad mínima vertical
        EnsureVerticalVelocity();
    }

    private void LimitVelocity()
    {
        if (ballRb.velocity.magnitude > maxVelocity)
        {
            ballRb.velocity = ballRb.velocity.normalized * maxVelocity;
        }
    }

    private void EnsureVerticalVelocity()
    {
        if (Mathf.Abs(ballRb.velocity.y) < minVerticalVelocity)
        {
            float newVerticalVelocity = minVerticalVelocity * Mathf.Sign(ballRb.velocity.y != 0 ? ballRb.velocity.y : 1);
            ballRb.velocity = new Vector2(ballRb.velocity.x, newVerticalVelocity);
        }
    }

    public void ResetBall()
    {
        transform.parent = FindObjectOfType<Player>().transform;
        transform.position = startposition;
        
        ballRb.velocity = Vector2.zero;
        isBallMoving = false;
    }
}