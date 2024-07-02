using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : Attack
{
    [Header("Bite")]
    public float damage;
    public Timer attackTimer;
    public GameObject attackZone;
    private AudioSource attackSound;

    protected override void Awake()
    {
        base.Awake();
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AttackProcess()
    {
        base.AttackProcess();
        user.GetComponent<EnemyMovement>().StopMovement();
        if (attackTimer.timeLeft == 0)
        {
            attackSound.Play();
            DeactivateAttackZone();
            Deactivate();
        }
    }

    public override void Activate()
    {
        base.Activate();
        attackTimer.StartTimer();
        ActivateAttackZone();
    }

    public void ActivateAttackZone()
    {
        sprite.GetComponent<AnimationController>().ForcePlayAnimation(animationName);
        attackZone.SetActive(true);
        Collider2D nearestEnemy = Calculation.FindNearestTargetWithinRadius(transform.position, attackTargets);
        attackZone.transform.position = nearestEnemy.transform.position;
        attackZone.GetComponent<AttackZone>().damage = damage;
    }

    public void DeactivateAttackZone()
    {
        attackZone.SetActive(false);
    }
}
