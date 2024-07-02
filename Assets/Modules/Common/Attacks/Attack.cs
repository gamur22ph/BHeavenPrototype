using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Attack : MonoBehaviour
{
    [Header("Attack")]
    public AttackData attackData;
    public GameObject sprite;
    public string animationName;
    [HideInInspector]
    public Timer cooldownTimer;
    public float attackRange;
    public LayerMask targetMask;
    protected Collider2D[] attackTargets = new Collider2D[1];
    Collider2D nearestEnemy;
    private bool activated;
    protected GameObject user;

    protected virtual void Awake()
    {
        cooldownTimer = GetComponent<Timer>();
        user = transform.parent.parent.gameObject;
        FindTargets();
    }

    protected virtual void FixedUpdate()
    {
        FindTargets();
    }

    public void FindTargets()
    {
        attackTargets = Physics2D.OverlapCircleAll(transform.position, attackRange, targetMask);
    }

    public virtual void AttackProcess()
    {
        // Always override this, this is the attack frames
        // Always deactivated after the end of every attack.
    }

    public bool IsActivated()
    {
        return activated;
    }

    public virtual void Activate()
    {
        cooldownTimer.StartTimer();
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }

    public bool HasEnemyInRange()
    {
        if (attackTargets.Length > 0)
        {
            return true;
        }
        return false;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
