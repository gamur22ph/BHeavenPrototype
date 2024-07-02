using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownSword : Projectile
{
    [Header("ThrownSword")]
    public float damage;
    public float rotationSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Mathf.Log(attackMask.value, 2))
        {
            other.GetComponent<IDamageable>().Damage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
