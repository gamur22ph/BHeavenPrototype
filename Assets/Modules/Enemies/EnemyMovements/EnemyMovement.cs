using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovement : MonoBehaviour
{
    protected Vector3 direction = Vector3.zero;
    protected Rigidbody2D rb;
    public abstract void HandleMovement(float movementSpeed);

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public void StopMovement()
    {
        rb.velocity = Vector3.zero;
    }
}
