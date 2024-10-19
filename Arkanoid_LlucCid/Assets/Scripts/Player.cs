using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
    }
}
