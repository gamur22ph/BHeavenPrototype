using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleEnemyMovement : EnemyMovement
{
    private GameObject target;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public override void HandleMovement(float movementSpeed)
    {
        direction = (target.transform.position - transform.position).normalized;
        rb.velocity = direction * movementSpeed;
    }

    
}
