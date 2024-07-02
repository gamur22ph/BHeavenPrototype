using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseMovementSpeed;
    float currentMovementSpeed;
    public float bonusMovementSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMovementSpeed = baseMovementSpeed;
    }

    public void HandleMovement()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalDirection, verticalDirection).normalized * currentMovementSpeed;
    }

    public bool IsMoving() {
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
    }

    public float GetHorizontalMovement()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
