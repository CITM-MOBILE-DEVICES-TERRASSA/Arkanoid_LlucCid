using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;
    private Rigidbody2D ballRb;
    private bool isBallMoving;
    void Start()
    {
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
}
