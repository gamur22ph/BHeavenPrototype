using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordThrower : Attack
{
    public float damage;
    public float projectileSpeed;
    public GameObject sword;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AttackProcess()
    {
        base.AttackProcess();

    }

    public override void Activate() 
    {
        base.Activate();
        SpawnRotatingSword();
        Deactivate();
    }

    public void SpawnRotatingSword()
    {
        
        Collider2D nearestEnemy = Calculation.FindNearestTargetWithinRadius(transform.position, attackTargets);
        Vector3 projectileDirection = (nearestEnemy.transform.position - user.transform.position).normalized;
        GameObject newRotatingSword = Instantiate(sword, user.transform.position + projectileDirection * 0.5f, Quaternion.identity);
        newRotatingSword.GetComponent<ThrownSword>().damage = damage;
        newRotatingSword.GetComponent<ThrownSword>().projectileSpeed = projectileSpeed;
        newRotatingSword.GetComponent<ThrownSword>().attackDirection = projectileDirection;

    }

}
