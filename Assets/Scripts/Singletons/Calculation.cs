using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculation
{
    public static Collider2D FindNearestTargetWithinRadius(Vector3 position, Collider2D[] targets)
    {
        Collider2D nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Collider2D target in targets)
        {
            float distanceToTarget = Vector2.Distance(position, target.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }
        if (nearestTarget == null)
        {
            return null;
        }
        return nearestTarget;
    }
}
