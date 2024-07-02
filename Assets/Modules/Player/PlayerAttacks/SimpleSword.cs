using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSword : Attack
{
    [Header("SimpleSword")]
    [SerializeField] private Timer swingTimer;
    [HideInInspector]
    public float currentDamage;
    public float baseDamage;
    [HideInInspector]
    public float currentCooldown;
    [HideInInspector]
    private float baseCooldown;
    public GameObject slashSprite;
    public AudioSource attackSound;

    protected override void Awake()
    {
        base.Awake();
        attackSound = GetComponent<AudioSource>();
        currentDamage = baseDamage;
        baseCooldown = cooldownTimer.waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyBonusDamage(float newBonusDamage)
    {
        currentDamage = baseDamage + newBonusDamage;
    }

    public void ApplyBonusAttackRate(float newBonusAttackRate)
    {
        cooldownTimer.waitTime = baseCooldown - newBonusAttackRate;
    }

    public override void AttackProcess()
    {
        if (swingTimer.timeLeft == 0)
        {
            Deactivate();
        }
    }

    public override void Activate()
    {
        base.Activate();
        attackSound.Play();
        swingTimer.StartTimer();
        sprite.GetComponent<AnimationController>().ForcePlayAnimation(animationName);

        Collider2D nearestTarget = Calculation.FindNearestTargetWithinRadius(transform.position, attackTargets);
        RaycastHit2D[] enemyHit = Physics2D.CircleCastAll((nearestTarget.transform.position - transform.position).normalized * (attackRange/2) + transform.position, (attackRange/2), Vector2.zero, 0, targetMask);
        
        if (nearestTarget.transform.position.x - transform.position.x < 0)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            sprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        

        SpawnSlashFXAt(nearestTarget.transform.position);

        foreach(RaycastHit2D enemy in enemyHit)
        {
            enemy.collider.GetComponent<IDamageable>().Damage(currentDamage);
        }
    }

    void SpawnSlashFXAt(Vector3 slashPosition)
    {
        GameObject newSlashSprite = Instantiate(slashSprite);
        newSlashSprite.SetActive(true);
        newSlashSprite.GetComponent<Animator>().Play("Slash");
        var angle = Mathf.Atan2(slashPosition.y - transform.position.y, slashPosition.x - transform.position.x) * Mathf.Rad2Deg;
        newSlashSprite.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle));
        newSlashSprite.transform.position = slashPosition;
        Destroy(newSlashSprite, 0.3f);
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        /*
        if (attackTargets?.Length > 0)
        {
            Gizmos.DrawWireSphere((attackTargets[0].gameObject.transform.position - transform.position).normalized * 0.5f + transform.position, attackRange * 0.5f);
        }
        */
    }
}
