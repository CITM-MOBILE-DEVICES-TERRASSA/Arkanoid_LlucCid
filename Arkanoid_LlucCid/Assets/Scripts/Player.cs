using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private float bounds = 2.0f;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");


        Vector2 playerPosition = transform.position;
        playerPosition.x = Math.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
        transform.position = playerPosition;
    }
}
